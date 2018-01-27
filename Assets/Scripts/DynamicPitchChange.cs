using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio;

    [SerializeField]
    AudioClip[] my_clips;
    float[] pitchChanges;

    int numClips = 4;

    int currentClip = 0;

	// Use this for initialization
	void Start () {

    }

    public void PlaysClips(AudioClip clip, float[] pitches)
    {
        my_audio = GameController.Instance.AudioSource;

        this.numClips = pitches.Length;

        my_clips = new AudioClip[numClips];
        pitchChanges = new float[numClips];

        SetupAudioClips(clip, pitches);

        StartCoroutine(PlaySoundsWithPitchCoroutine(my_audio, my_clips, pitchChanges));
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space) && !my_audio.isPlaying)
        {
            my_audio.clip = my_clips[currentClip];
            my_audio.pitch = pitchChanges[currentClip];
            my_audio.Play();
            currentClip++;
            if (currentClip >= my_clips.Length)
                currentClip = 0;
        }

        //Debug.Log(my_audio.time.ToString());
        //Debug.Log(my_audio.clip.length);
        //Debug.Log(my_audio.timeSamples);
    }

    public void SetupAudioClips(AudioClip clip,float[] pitches)
    {
        float clipLength = clip.length / numClips;

        for (int x = 0; x < my_clips.Length; x++)
        {
            float start = clipLength * x;
            float end = start + clipLength;
            my_clips[x] = MakeSubclip(clip, start, end);
            pitchChanges[x] = pitches[x];
        }
    }

    private AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
        /* Create a new audio clip */
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);
        AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, 2, frequency, false);
        /* Create a temporary buffer for the samples */
        float[] data = new float[samplesLength];
        /* Get the data from the original clip */
        clip.GetData(data, (int)(frequency * start));
        /* Transfer the data to the new clip */
        newClip.SetData(data, 0);
        /* Return the sub clip */
        return newClip;
    }

    public AudioClip Combine(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0)
            return null;

        int length = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
                continue;

            length += clips[i].samples * clips[i].channels;
        }

        float[] data = new float[length];
        length = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
                continue;

            float[] buffer = new float[clips[i].samples * clips[i].channels];
            clips[i].GetData(buffer, 0);
            //System.Buffer.BlockCopy(buffer, 0, data, length, buffer.Length);
            buffer.CopyTo(data, length);
            length += buffer.Length;
        }

        if (length == 0)
            return null;

        AudioClip result = AudioClip.Create("Combine", length / 2, 2, 44100, false);
        result.SetData(data, 0);

        return result;
    }

    public AudioClip[] GetAudioClips()
    {
        return my_clips;
    }

    public IEnumerator PlaySoundsWithPitchCoroutine(AudioSource src, AudioClip[] clips, float[] pitches)
    {
        if (clips.Length == pitches.Length)
        {
            int i = 0;
            while (i < clips.Length)
            {

                src.clip = clips[i];
                src.pitch = pitches[i];
                src.Play();

                yield return new WaitForSeconds(clips[i].length);

                i++;
            }
        }
        else
        {
            Debug.LogWarning("Clips count doesn't match with pitches count");
        }
    }
}
