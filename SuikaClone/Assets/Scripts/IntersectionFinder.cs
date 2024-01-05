using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionFinder : MonoBehaviour
{
    public LineRenderer lineRenderer;
    Vector3[] startingLineRendererPoints = null;

	// Use this for initialization
	void Start () {
    }
	
	// Fixed update is used for physics
	void FixedUpdate ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down);
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, hitInfo.point);

    }
}