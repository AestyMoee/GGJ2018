using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio = null;
    AudioClip my_clip = null;

    [SerializeField]
    AudioClip[] my_clips;
    float[] pitchChanges;

    int numClips = 3; //Default
    int current = 0;

    bool shouldPlay = false;
    bool shouldLoop = false;
    bool hasReset = false;

    float nextPitchChange = 0;

    private void Update()
    {
        if(my_audio != null)
        {
            UpdatePitches();

            if (current == pitchChanges.Length - 1)
                Debug.Log("Hit");
            if (my_audio.time >= nextPitchChange * current && !hasReset)
            {
                Debug.Log("Change Pitch");
                my_audio.pitch = pitchChanges[current];
                current++;
            }

            if (current >= pitchChanges.Length)
            {
                hasReset = true;
                current = 0;
                if (!shouldLoop)
                    shouldPlay = false;
            }

            if (!my_audio.isPlaying && shouldPlay)
            {
                //my_audio.clip = my_clips[current];
                //.pitch = pitchChanges[current];
                my_audio.Play();
                hasReset = false;
            }
            InputManager();
        }
        
    }

    private void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (my_audio.isPlaying)
                PlaybackInterrupt();
            else
            {
                current = 0;
                shouldPlay = true;
                shouldLoop = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shouldLoop = false;
        }
    }

    public void StartPlayingAudio()
    {
        shouldPlay = true;
    }

    public void UpdatePitches()
    {
        pitchChanges = GameController.Instance.GetCurrentPitches();
    }

    public void PlaysClips(AudioClip clip, float[] pitches)
    {
        //Game controller calls this function, no way it doesn't exist
        my_audio = GameController.Instance.AudioSource;
        my_clip = clip;

        my_audio.clip = my_clip;
        
        this.numClips = pitches.Length;

        my_clips = new AudioClip[numClips];
        pitchChanges = new float[numClips];

        SetupAudioClips(clip, pitches);

        StartPlayingAudio();
        //StartCoroutine(PlaySoundsWithPitchCoroutine(my_audio, my_clips, pitchChanges));
    }
    //Sets up the separated audio clips and pitches array;
    private void SetupAudioClips(AudioClip clip, float[] pitches)
    {
        float clipLength = clip.length / numClips;
        nextPitchChange = clipLength;

        for (int x = 0; x < my_clips.Length; x++)
        {
            float start = clipLength * x;
            float end = start + clipLength;
            my_clips[x] = MakeSubclip(clip, start, end, x);
            pitchChanges[x] = pitches[x];
        }
    }

    public void PlaybackInterrupt()
    {
        if(my_audio != null)
        {
            my_audio.Stop();
            shouldPlay = false;
            current = 0;
        }
    }

    //Function responsible for splitting up the audio clip into parts (one at a time)
    private AudioClip MakeSubclip(AudioClip clip, float start, float stop, int j)
    {
        /* Create a new audio clip */
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);
        AudioClip newClip = AudioClip.Create(clip.name + "-sub" + j, samplesLength, 2, frequency, false);
        /* Create a temporary buffer for the samples */
        float[] data = new float[samplesLength];
        /* Get the data from the original clip */
        clip.GetData(data, (int)(frequency * start));
        /* Transfer the data to the new clip */
        newClip.SetData(data, 0);
        /* Return the sub clip */
        return newClip;
    }


}
