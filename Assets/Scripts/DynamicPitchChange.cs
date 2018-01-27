﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio;

    [SerializeField]
    AudioClip[] my_clips;
    float[] pitchChanges;

    AudioClip modifiedClip;

    int numClips = 4;

    int currentClip = 0;

	// Use this for initialization
	void Start () {
        my_audio = GetComponent<AudioSource>();
        my_clips = new AudioClip[numClips];
        pitchChanges = new float[numClips];

        SetupAudioClips(my_audio);

        modifiedClip = Combine(my_clips);

        PlaySoundsWithPitch(my_audio, pitchChanges);
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

    public void SetupAudioClips(AudioSource aud)
    {
        float clipLength = aud.clip.length / numClips;

        for (int x = 0; x < my_clips.Length; x++)
        {
            float start = clipLength * x;
            float end = start + clipLength;
            my_clips[x] = MakeSubclip(aud.clip, start, end);
            pitchChanges[x] = Random.Range(0.1f, 2f);
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

    public void PlaySoundsWithPitch(AudioSource src, float[] pitches)
    {
            
    }
}
