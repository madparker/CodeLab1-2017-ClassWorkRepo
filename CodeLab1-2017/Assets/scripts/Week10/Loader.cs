﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AsteroidData loadAD = new AsteroidData("Asteroid.txt");

		print(loadAD.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
