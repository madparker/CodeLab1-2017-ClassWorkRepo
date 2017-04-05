using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

		Vector3 pos = asteroids[0].transform.position;
		Vector3 scale = asteroids[0].transform.localScale;

		AsteroidData ad = new AsteroidData(pos, scale);

		ad.Save("Asteroid.txt");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
