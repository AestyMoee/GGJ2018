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
    GameObject prefabBlackOrb = null;
    [SerializeField]
    GameObject prefabWhiteOrb = null;

    [SerializeField]
    private GameObject[] tracks;

    public AudioSource AudioSource { get; private set; }

    public float TrackLenght { get; private set; }

    private int clipCutCount;

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

    // Use this for initialization
    void Start () {
#if !UNITY_EDITOR
        levelToLoadAtStart = 0;
#endif

        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;

        TrackLenght = tracks[0].GetComponent<MeshRenderer>().bounds.size.x * tracks[0].transform.localScale.x * 2;

        LoadLevel(levelToLoadAtStart);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(int levelId)
    {
        LevelStruct level = levels[levelId];
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

            for(int i=0;i<level.pitches.Length;++i)
            {
                if(level.pitches[i] != 1)
                {
                    EventDelegate.FireChangeWaveFormPitch(i, (level.pitches[i] - 1)*4);
                    EventDelegate.FireChangeGhostWaveFormPitch(i, (level.pitches[i] - 1) * 4);

                    GameObject orb;
                    if (level.pitches[i] > 1)
                    {
                        orb = Instantiate(prefabBlackOrb);
                    }
                    else
                    {
                        orb = Instantiate(prefabWhiteOrb);
                    }

                    orb.GetComponent<OrbBehaviour>().PitchModifier = (level.pitches[i] - 1) * 4;
                    orb.transform.parent = tracks[randomTrackIds[i]].transform;
                    Vector3 positionLens = orb.transform.position;
                    positionLens.z = 0;
                    orb.transform.localPosition = positionLens;

                    int randomPart = 0;
                    do
                    {
                        randomPart = Random.Range(0, 4);
                        orb.GetComponent<OrbBehaviour>().SetPosition(randomPart);
                    } while (randomPart == i);
                    

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
    }

    public int GetClipCutCount()
    {
        return (clipCutCount != 0 ? clipCutCount : 1);
    }
}
