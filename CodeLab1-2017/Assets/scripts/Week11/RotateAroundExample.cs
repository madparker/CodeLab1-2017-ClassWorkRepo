using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundExample : MonoBehaviour {

	public GameObject target;
	public Vector3 axis;

	private float angle = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(target.transform.position, axis, angle); //Rotate an object around a point and an axis, by "angle" degrees
	}
}
