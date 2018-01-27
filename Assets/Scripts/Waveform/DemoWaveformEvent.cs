using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoWaveformEvent : MonoBehaviour {

    [SerializeField]
    private int partCount = 5;

    [SerializeField]
    private float pitchModifier = 0.1f;


    private int currentModifierId = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentModifierId--;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentModifierId++;
        }

        currentModifierId = Mathf.Clamp(currentModifierId, 0, partCount - 1);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventDelegate.FireChangeWaveFormPitch(partCount, currentModifierId, pitchModifier);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventDelegate.FireChangeWaveFormPitch(partCount, currentModifierId, -pitchModifier);
        }
	}
}
