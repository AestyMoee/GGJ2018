using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour {

    [SerializeField]
    private float pitchModifier = 0.1f;

    public float PitchModifier { get { return pitchModifier; } private set { pitchModifier = value; } }
    
    public int CurrentPosition { get; set; }

    [SerializeField]
    LineRenderer lineRenderer;

    bool receiveLaser = false;

    // Use this for initialization
    void Start()
    {
        EventDelegate.FireChangeGhostWaveFormPitch(CurrentPosition, pitchModifier);
    }

    private void Update()
    {
        if (!receiveLaser)
        {
            lineRenderer.positionCount = 0;
        }
        else
        {
            receiveLaser = false;
        }
    }

    public void MoveLeft()
    {
        EventDelegate.FireChangeGhostWaveFormPitch(CurrentPosition, pitchModifier);
        EventDelegate.FireChangeGhostWaveFormPitch(CurrentPosition + 1, -pitchModifier);
    }

    public void MoveRight()
    {
        EventDelegate.FireChangeGhostWaveFormPitch(CurrentPosition, pitchModifier);
        EventDelegate.FireChangeGhostWaveFormPitch(CurrentPosition - 1, -pitchModifier);
    }

    public void TouchOrb(Vector3 inPosition)
    {
        receiveLaser = true;
        RaycastHit hit;
        inPosition.z += 0.1f;
        if(Physics.Raycast(inPosition,Vector3.forward,out hit, 10))
        {
            if(hit.collider.tag == "Orb")
            {
                hit.collider.GetComponent<OrbBehaviour>().TouchOrb(hit.point);
            }
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, inPosition);
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
