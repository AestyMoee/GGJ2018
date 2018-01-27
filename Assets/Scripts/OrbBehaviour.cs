using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbBehaviour : MonoBehaviour {

    [SerializeField]
    private float pitchModifier = 0.1f;
    [SerializeField]
    private int partCount = 5;
    [SerializeField]
    private int currentPosition = 2;

    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();

        EventDelegate.FireChangeWaveFormPitch(partCount, currentPosition, pitchModifier);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
	}

    public void MoveLeft()
    {
        if(currentPosition > 0)
        {
            currentPosition--;
            EventDelegate.FireChangeWaveFormPitch(partCount, currentPosition, pitchModifier);
            EventDelegate.FireChangeWaveFormPitch(partCount, currentPosition +1, -pitchModifier);
        }
    }

    public void MoveRight()
    {
        if (currentPosition < partCount -1)
        {
            currentPosition++;
            EventDelegate.FireChangeWaveFormPitch(partCount, currentPosition, pitchModifier);
            EventDelegate.FireChangeWaveFormPitch(partCount, currentPosition - 1, -pitchModifier);
        }
    }

    public void TouchOrb(Vector3 inPosition)
    {
        RaycastHit hit;
        if(Physics.Raycast(inPosition,Vector3.forward,out hit, 100))
        {
            if(hit.collider.tag == "Wall")
            {

            }
        }
    }
}
