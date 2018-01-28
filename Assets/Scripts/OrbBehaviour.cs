using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour {

    [SerializeField]
    private float pitchModifier = 0.1f;

    public float PitchModifier { get { return pitchModifier; } set { pitchModifier = value; } }

    [SerializeField]
    private int currentPosition = 2;

    [SerializeField]
    LineRenderer lineRenderer;

    bool receiveLaser = false;

	// Use this for initialization
	void Start () {
        EventDelegate.FireChangeGhostWaveFormPitch(currentPosition, pitchModifier);
    }

    private void Update()
    {
        if(!receiveLaser)
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
        if(currentPosition > 0)
        {
            currentPosition--;
            EventDelegate.FireChangeGhostWaveFormPitch(currentPosition, pitchModifier);
            EventDelegate.FireChangeGhostWaveFormPitch(currentPosition +1, -pitchModifier);
            SetPosition(currentPosition);
        }
    }

    public void MoveRight()
    {
        if (currentPosition < GameController.Instance.GetClipCutCount() -1)
        {
            currentPosition++;
            EventDelegate.FireChangeGhostWaveFormPitch(currentPosition, pitchModifier);
            EventDelegate.FireChangeGhostWaveFormPitch(currentPosition - 1, -pitchModifier);
            SetPosition(currentPosition);
        }
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

    public void SetPosition(int idPart)
    {
        currentPosition = idPart;

        Vector3 position = transform.localPosition;

        position.x = (GameController.Instance.TrackLenght / GameController.Instance.GetClipCutCount() * idPart + (GameController.Instance.TrackLenght / GameController.Instance.GetClipCutCount()) / 2) - GameController.Instance.TrackLenght/2;

        transform.localPosition = position;
    }
}
