using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbBehaviour : MonoBehaviour {

    [SerializeField]
    private float pitchModifier = 0.1f;

    public float PitchModifier { get { return pitchModifier; } set { pitchModifier = value; } }

    [SerializeField]
    private int currentPosition = 2;

    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();

        EventDelegate.FireChangeGhostWaveFormPitch(currentPosition, pitchModifier);
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
        RaycastHit hit;
        if(Physics.Raycast(inPosition,Vector3.forward,out hit, 100))
        {
            if(hit.collider.tag == "Wall")
            {

            }
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
