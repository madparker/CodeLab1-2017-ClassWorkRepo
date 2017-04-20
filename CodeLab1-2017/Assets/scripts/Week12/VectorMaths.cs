using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMaths : MonoBehaviour {

	public Vector3 startPoint = new Vector3(0,0,0);
	public Vector3 vec1 = new Vector3(10, 0, 0);
	public Vector3 vec2 = new Vector3(0, 0, 10);

	public Vector3 inAngle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Draw a Debug ray
		Debug.DrawRay(startPoint, vec1, Color.green);

		//Print out the magnitude of a vector
		Debug.Log("Vec1 Mag: " + vec1.magnitude);
		//Print out the normalized version of vector
		Debug.Log("Vec1 Normalized:" + Vector3.Normalize(vec1));

		//Print out the Dot Product of 2 vectors, in this case 0
		//(for more info about Dot Products, look at line 43 of
		//MoveTowardTarget
		Debug.Log("Dot: " + Vector3.Dot(Vector3.right, Vector3.down));

		//Draw a 2 vectors to describe a plane
		Debug.DrawRay(startPoint, vec1, Color.white);
		Debug.DrawRay(startPoint, vec2, Color.white);


		//create a cross product of the 2 rays
		//(for more info about Dot Products, look at line 68 of
		//MoveTowardTarget
		Vector3 cross = Vector3.Cross(vec1, vec2);

		//Draw the cross product (normal to the plane)
		Debug.DrawRay(startPoint, cross, Color.yellow);

		//Draw a vector going into the plane
		Debug.DrawRay(startPoint, inAngle, Color.red);

		//Get the reflection of inAngle using the normal
		Vector3 reflection = Vector3.Reflect(inAngle, cross.normalized);

		//Draw the reflection of the inAngle
		Debug.DrawRay(startPoint, -reflection, Color.blue);
	}
}
