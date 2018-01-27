using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio = null;

    [SerializeField]
    AudioClip[] my_clips;
    float[] pitchChanges;

    int numClips = 4;

    int currentClip = 0;

    public void PlaysClips(AudioClip clip, float[] pitches)
    {
        my_audio = GameController.Instance.AudioSource;

        this.numClips = pitches.Length;

        my_clips = new AudioClip[numClips];
        pitchChanges = new float[numClips];

        SetupAudioClips(clip, pitches);

        StartCoroutine(PlaySoundsWithPitchCoroutine(my_audio, my_clips, pitchChanges));
    }

    public void PlaybackInterrupt()
    {
        if(my_audio != null)
        {
            StopCoroutine("PlaySoundsWithPitchCoroutine");
            if (my_audio.isPlaying)
                my_audio.Stop();
        }
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

    //Sets up the separated audio clips and pitches array;
    private void SetupAudioClips(AudioClip clip,float[] pitches)
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

    //Function responsible for splitting up the audio clip into parts (one at a time)
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


}
