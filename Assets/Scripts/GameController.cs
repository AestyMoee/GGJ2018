using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {

    [System.Serializable]
    public struct LevelStruct
    {
        [Range(1,4)]
        public int trackCount;
        public AudioClip clip;
        public float[] pitches;

        public GameObject[] Pedestals;
    }

    public static GameController Instance { get; private set; }

    [SerializeField]
    private WaveformGenerator waveform = null;
    [SerializeField]
    private DynamicPitchChange pitchChange = null;


    [SerializeField]
    List<LevelStruct> levels;

    [SerializeField]
    int levelToLoadAtStart = 0;

    [SerializeField]
    private GameObject[] tracks;

    public AudioSource AudioSource { get; private set; }

    public float TrackLenght { get; private set; }

    private int clipCutCount;

    private int currentLevel = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Game Controller already exist");
            enabled = false;
        }
    }

    private int currentTrack = 0;

    private bool blockVerticalInput = false;
    private bool blockHorizontalInput = false;

    // Use this for initialization
    void Start () {
#if !UNITY_EDITOR
        levelToLoadAtStart = 0;
#endif

        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;

        TrackLenght = tracks[0].GetComponent<MeshRenderer>().bounds.size.x * tracks[0].transform.localScale.x;

        LoadLevel(levelToLoadAtStart);
    }
	
	// Update is called once per frame
	void Update () {

        UnlockInput();

        if(!blockVerticalInput)
        {
            MoveCursor();
        }
        if(!blockHorizontalInput)
        {
            MoveLens();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            GetCurrentPitches();
        }
	}

    private void UnlockInput()
    {
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            blockVerticalInput = false;
        }

        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            blockHorizontalInput = false;
        }
    }

    private void MoveCursor()
    {
        if(Input.GetAxisRaw("Vertical") < 0)
        {
            GoToPreviousTrack();
            blockVerticalInput = true;
        }
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            GoToNextTrack();
            blockVerticalInput = true;
        }
    }

    private void MoveLens()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            tracks[currentTrack].GetComponentInChildren<PedestalBehaviour>().MoveLeft();
            blockHorizontalInput = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            tracks[currentTrack].GetComponentInChildren<PedestalBehaviour>().MoveRight();
            blockHorizontalInput = true;
        }
    }

    private void GoToPreviousTrack()
    {
        for(int i=currentTrack-1; i >= 0; --i)
        {
            if(tracks[i].activeSelf)
            {
                currentTrack = i;
                UpdateSelectedTrack();
                break;
            }
        }
    }

    private void GoToNextTrack()
    {
        for (int i = currentTrack + 1; i < tracks.Length; ++i)
        {
            if (tracks[i].activeSelf)
            {
                currentTrack = i;
                UpdateSelectedTrack();
                break;
            }
        }
    }

    private void GoToFirstTrack()
    {
        for (int i = 0; i < tracks.Length; ++i)
        {
            if (tracks[i].activeSelf)
            {
                currentTrack = i;
                UpdateSelectedTrack();
                break;
            }
        }
    }

    public void UpdateSelectedTrack()
    {
        for(int i=0;i<tracks.Length;++i)
        {
            if (tracks[i].activeSelf)
            {
                Material pedestalMat = tracks[i].transform.GetChild(0).GetComponent<MeshRenderer>().material;

                if (i == currentTrack)
                {
                    pedestalMat.SetFloat("_Selected", 1);
                }
                else
                {
                    pedestalMat.SetFloat("_Selected", 0);
                }
            }
        }
    }

    public void LoadLevel(int levelId)
    {
        LevelStruct level = levels[levelId];
        currentLevel = levelId;
        clipCutCount = level.pitches.Length;


        for (int i = 0; i < tracks.Length; ++i)
        {
            tracks[i].SetActive(true);
        }

        if (waveform != null)
        {
            System.Random rnd = new System.Random();
            int[] randomTrackIds = Enumerable.Range(0, 4).OrderBy(r => rnd.Next()).ToArray();

            waveform.DrawWaveform(level.clip);

            int currentLens = 0;

            for(int i=0;i<level.pitches.Length;++i)
            {
                if(level.pitches[i] != 1)
                {
                    EventDelegate.FireChangeWaveFormPitch(i, (level.pitches[i] - 1)*6);
                    EventDelegate.FireChangeGhostWaveFormPitch(i, (level.pitches[i] - 1) * 6);

                    GameObject orb;
                    orb = Instantiate(level.Pedestals[currentLens]);
                    currentLens++;
                    
                    orb.transform.parent = tracks[randomTrackIds[i]].transform;
                    Vector3 positionLens = orb.transform.position;
                    positionLens.z = 0;
                    orb.transform.localPosition = positionLens;

                    int randomPart = 0;
                    do
                    {
                        randomPart = Random.Range(0, ( 5 - orb.GetComponent<PedestalBehaviour>().orbs.Length));
                    } while (randomPart == i);

                    orb.GetComponent<PedestalBehaviour>().SetPosition(randomPart);

                }
                else
                {
                    tracks[randomTrackIds[i]].SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogError("Waveform Generator not found");
        }

        if (pitchChange != null)
        {
            pitchChange.PlaysClips(level.clip, level.pitches);
        }
        else
        {
            Debug.LogError("dynamicPitchChange not found");
        }

        GoToFirstTrack();
    }

    public int GetClipCutCount()
    {
        return (clipCutCount != 0 ? clipCutCount : 1);
    }

    public float[] GetCurrentPitches()
    {
        float[] returnArray = new float[GetClipCutCount()];

        for(int i=0;i<returnArray.Length;++i)
        {
            returnArray[i] = levels[currentLevel].pitches[i];
        }

        for(int i=0;i<tracks.Length;++i)
        {
            if(tracks[i].activeSelf)
            {
                OrbBehaviour[] orbsOnTrack = tracks[i].GetComponentsInChildren<OrbBehaviour>();

                for(int j=0;j<orbsOnTrack.Length;++j)
                {
                    returnArray[orbsOnTrack[j].CurrentPosition] += (orbsOnTrack[j].PitchModifier/6f);
                }
            }
        }

        return returnArray;
    }
}
