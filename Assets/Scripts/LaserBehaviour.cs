using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

    [SerializeField]
    LineRenderer lineRenderer = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        Debug.DrawLine(transform.position, Vector3.forward * 10, Color.red);

        if(Physics.Raycast(transform.position,Vector3.forward, out hit,10))
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
