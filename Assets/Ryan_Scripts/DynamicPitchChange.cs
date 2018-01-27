using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio;

    [SerializeField]
    AudioClip[] my_clips;

    int numClips = 3;

    int currentClip = 0;

	// Use this for initialization
	void Start () {
        my_audio = GetComponent<AudioSource>();
        my_clips = new AudioClip[numClips];

        float clipLength = my_audio.clip.length / numClips;

        for(int x = 0; x < my_clips.Length; x++)
        {
            float start = clipLength * x;
            float end = start + clipLength;
            my_clips[x] = MakeSubclip(my_audio.clip, start, end);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space) && !my_audio.isPlaying)
        {
            my_audio.clip = my_clips[currentClip];
            my_audio.Play();
            currentClip++;
            if (currentClip >= my_clips.Length)
                currentClip = 0;

        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            my_audio.pitch += 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            my_audio.pitch -= 0.25f;
        }

        //Debug.Log(my_audio.time.ToString());
        //Debug.Log(my_audio.clip.length);
        //Debug.Log(my_audio.timeSamples);
    }

    void SplitAudio(AudioSource aud)
    {
        float clipLen = aud.clip.length / 5;

        int samples = aud.clip.samples;

        for(int x = 0; x < my_clips.Length; x++)
        {
            int frequency = aud.clip.frequency;
            //Debug.Log(frequency);
            float timeLength = aud.clip.length - aud.clip.length / 5;
            int samplesLength = (int)(frequency * timeLength);

            my_clips[x] = AudioClip.Create("Clip - " + x,
                samples, 2, aud.clip.frequency, false);

            float[] data = new float[samplesLength];

            //
            aud.clip.GetData(data, (int) (frequency * (clipLen*x)));

            my_clips[x].SetData(data, 0);
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
}
