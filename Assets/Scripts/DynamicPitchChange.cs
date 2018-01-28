using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio = null;

    [SerializeField]
    AudioClip[] my_clips;
    float[] pitchChanges;

    int numClips = 3; //Default
    int current = 0;
    bool interrupted = false;
    bool shouldPlay = false;

    private void Update()
    {
        if(my_audio != null)
        {
            if(!my_audio.isPlaying && shouldPlay)
            {
                my_audio.clip = my_clips[current];
                my_audio.pitch = pitchChanges[current];
                my_audio.Play();
                current++;
                if (current >= my_clips.Length)
                {
                    current = 0;
                    shouldPlay = false;
                }
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (my_audio.isPlaying)
                    PlaybackInterrupt();
                else
                {
                    current = 0;
                    shouldPlay = true;
                }
            }
        }
        
    }

    public void StartPlayingAudio()
    {
        shouldPlay = true;
    }

    public void PlaysClips(AudioClip clip, float[] pitches)
    {
        Debug.Log("Playing clip: " + clip);
        Debug.Log("With pitches: " + pitches);

        //Game controller calls this function, no way it doesn't exist
        my_audio = GameController.Instance.AudioSource;
        
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

    //DEPRECATED
    public IEnumerator PlaySoundsWithPitchCoroutine(AudioSource src, AudioClip[] clips, float[] pitches)
    {
        if (clips.Length == pitches.Length)
        {
            int i = 0;
            while (i < clips.Length)
            {
                if (interrupted)
                    break;
                src.pitch = pitches[i];
                src.clip = clips[i];
                src.Play();

                i++;
                Debug.Log("Playing for:" + src.clip.name);
                yield return new WaitForSeconds(src.clip.length);
            }
        }
        else
        {
            Debug.LogWarning("Clips count doesn't match with pitches count");
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
