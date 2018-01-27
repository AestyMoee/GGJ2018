using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBehaviour : MonoBehaviour {

    LineRenderer lineRenderer = null;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,Vector3.forward,out hit,100))
        {
            if(hit.collider.tag == "Orb")
            {
                hit.collider.GetComponent<OrbBehaviour>().TouchOrb(hit.point);
            }


            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
	}
}
