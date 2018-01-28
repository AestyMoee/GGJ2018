using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPitchChange : MonoBehaviour {

    AudioSource my_audio = null;
    AudioClip my_clip = null;

    [SerializeField]
    float[] pitchChanges;

    int numClips = 3; //Default
    int current = 0;

    bool shouldPlay = false;
    bool shouldLoop = false;
    bool hasReset = false;
    bool targetHit = false;
    bool stopUpdating = false;

    bool disableInput = false;

    float nextPitchChange = 0;

    private void Update()
    {
        if(my_audio != null)
        {
            if(!stopUpdating)
            {
                if (!targetHit)
                {
                    UpdatePitches();

                    if (my_audio.time >= nextPitchChange * current && !hasReset)
                    {
                        //Debug.Log("Change Pitch");
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
                }
                else
                {
                    Debug.Log("Target hit, no more updating");
                    EventDelegate.FireLevelIsDone();
                    disableInput = true;
                    stopUpdating = true;
                }


                if (!my_audio.isPlaying && shouldPlay)
                {
                    //my_audio.clip = my_clips[current];
                    //.pitch = pitchChanges[current];
                    my_audio.Play();
                    hasReset = false;
                    shouldPlay = !targetHit;
                }
                if (!disableInput)
                    InputManager();
            }
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
                targetHit = PitchesMatchTarget();
                shouldPlay = true;
                shouldLoop = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shouldLoop = false;
        }
    }

    bool PitchesMatchTarget()
    {
        for(int i = 0; i < pitchChanges.Length; i++)
        {
            if (pitchChanges[i] != 1)
                return false;
        }
        return true;
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

        pitchChanges = new float[numClips];

        InitializeAllBools();

        InitializeClipAndPitchArray(clip, pitches);

        StartPlayingAudio();
        //StartCoroutine(PlaySoundsWithPitchCoroutine(my_audio, my_clips, pitchChanges));
    }
    //Sets up the separated audio clips and pitches array

    private void InitializeAllBools()
    {
        shouldPlay = false;
        shouldLoop = false;
        hasReset = false;
        targetHit = false;
        disableInput = false;
        stopUpdating = false;
    }

    private void InitializeClipAndPitchArray(AudioClip clip, float[] pitches)
    {
        nextPitchChange = clip.length / numClips;

        for (int x = 0; x < pitches.Length; x++)
        {
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
}
