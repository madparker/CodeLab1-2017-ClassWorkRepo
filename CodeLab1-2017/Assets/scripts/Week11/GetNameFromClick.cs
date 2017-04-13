﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNameFromClick : MonoBehaviour {

	private string objectName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){ //On mouse button down
			RaycastHit rayHit; //create a RaycastHit object

			//Call the Physics.Raycast function with Camera world position of the mouse, the rayHit object, and the far clipping plane
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Camera.main.farClipPlane)){
				Debug.Log(rayHit.collider.name); //Print the name of the object
			} else {
				Debug.Log("Hit nothing"); //if you hit nothing, print that
			}
		}
	}
}
