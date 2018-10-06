using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Simple script that draws a vector using a line renderer and slices along that vector
/// when the user clicks and drags the mouse
/// </summary>
[RequireComponent (typeof(LineRenderer))]
public class VectorCutter : MonoBehaviour 
{	
	LineRenderer lineRenderer;
	Vector3 cutStartPosition;
	bool isMouseHeld;

	void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		if(!isMouseHeld)
		{
			// Mouse button pressed - record the start position and enable the line renderer
			if(Input.GetMouseButton(0))
			{				
				cutStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				cutStartPosition.z = 0.0f;
				isMouseHeld = true;
				lineRenderer.SetPosition(0, cutStartPosition);
				lineRenderer.SetPosition(1, cutStartPosition);
				lineRenderer.enabled = true;
			}
		}
		else
		{
			// Mouse button being held down - update the line renderer
			Vector3 cutEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			cutEndPosition.z = 0.0f;
			lineRenderer.SetPosition(1, cutEndPosition);

			// Mouse button released - cut!
			if(!Input.GetMouseButton(0))
			{				
				SpriteSlicer2D.SliceAllSprites(cutStartPosition, cutEndPosition);
				lineRenderer.enabled = false;
				isMouseHeld = false;
			}
		}
	}
}
