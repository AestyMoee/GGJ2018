﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {

    [System.Serializable]
    public struct LevelStruct
    {
        public AudioClip clip;
        public float[] pitches;
    }

    public static GameController Instance { get; private set; }

    [SerializeField]
    private WaveformGenerator waveform = null;


    [SerializeField]
    List<LevelStruct> levels;

    [SerializeField]
    int levelToLoadAtStart = 0;

    public AudioSource AudioSource { get; private set; }

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

        LoadLevel(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(int levelId)
    {
        LevelStruct level = levels[levelId];
        AudioSource.clip = level.clip;

        if (waveform != null)
        {
            waveform.DrawWaveform(level.clip);

            for(int i=0;i<level.pitches.Length;++i)
            {
                if(level.pitches[i] != 1)
                {
                    EventDelegate.FireChangeWaveFormPitch(level.pitches.Length, i, (level.pitches[i] - 1)*4);
                    EventDelegate.FireChangeGhostWaveFormPitch(level.pitches.Length, i, (level.pitches[i] - 1) * 4);
                }
            }
        }
        else
        {
            Debug.LogError("Waveform Generator not found");
        }
    }
}