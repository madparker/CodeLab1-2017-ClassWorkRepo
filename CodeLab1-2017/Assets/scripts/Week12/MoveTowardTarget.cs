using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardTarget : MonoBehaviour {

	public Transform target;
	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Get the direction vector from the current position to the target
		Vector3 dir = target.position - transform.position;

		//Draw the direction array from the current position 
//		Debug.DrawRay(transform.position, dir, Color.magenta);

		//Normalize the dir vector
		dir.Normalize();

		//if we wanted to, we don't need to use Unity's fancy direction function
		//we can just calculate it ourselves!
//		dir = new Vector3(
//			dir.x/dir.magnitude,
//			dir.y/dir.magnitude,
//			dir.z/dir.magnitude);


		//print the Euler direction the transform is facing
		Debug.Log("Facing? " + transform.forward);

		//Print the normalized dir
		Debug.Log("Dir: " + dir);

		//confirm the magnitude of the dir is 1 after it's normalized (spoiler alert: it is)
		Debug.Log("Normalized dir? " + dir.magnitude);

		//Get the dot product of the "forward" and the dir
		//The dot product for normalized vectors will be
		//  1 if the vectors are the same
		// -1 if the vectors are opposite
		//  0 if the vectors are perpendicular
		// >0 if there is less than 90 degrees between the vectors
		// <0 if there is greater than 90 degrees between the vectors
		if(Vector3.Dot(transform.forward, dir) > 0){
			//if the target is in front of the object, draw a line
			Debug.DrawRay(transform.position, dir, Color.cyan);

			//move towards the target
			transform.position += dir * speed * Time.deltaTime;

			//rotate towards the target
			transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir), .1f);
		}

		//Draw a ray coming out of the front of the object
		Debug.DrawRay(transform.position, transform.forward * 3, Color.black);
		//Draw a ray coming out of the top of the object
		Debug.DrawRay(transform.position, transform.up * 3, Color.black);

		//if "space" is pressed
		if(Input.GetKeyDown(KeyCode.Space)){
			//Get the cross product of "forward" and "up" for this transform
			//The cross product will return the "normal" for a plane described
			//by two vectors. The "normal" is a vector perpendicular to both
			//vectors describing the ray
			Vector3 bulletDir = Vector3.Cross(transform.forward, transform.up);

			//Make a bullet
			GameObject b1 = Instantiate(Resources.Load("Bullet")) as GameObject;
			//give it velocity in the dir of the side of the object
			b1.GetComponent<Rigidbody>().velocity = bulletDir * 3;
			//Make another bullet
			GameObject b2 = Instantiate(Resources.Load("Bullet")) as GameObject;
			//give it velocity in the dir of the side of the object
			b2.GetComponent<Rigidbody>().velocity = bulletDir * -3;

			//Move the bullets to a position slightly offset from the current position
			b1.transform.position = transform.position + bulletDir;
			b2.transform.position = transform.position - bulletDir;
		}
	}
}
