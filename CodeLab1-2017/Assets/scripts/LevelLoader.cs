﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public float offsetX = 0;
	public float offsetY = 0;

	public string[] fileNames;
	public static int levelNum = 0;

	// Use this for initialization
	void Start () {
		string fileName = fileNames[levelNum];

		string filePath = Application.dataPath + "/" + fileName;

		StreamReader sr = new StreamReader(filePath);

		GameObject levelHolder = new GameObject("Level Holder");

		int yPos = 0;

		GameObject player = Instantiate(Resources.Load("Prefabs/Player") as GameObject);

		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			for(int xPos = 0; xPos < line.Length; xPos++){

				if(line[xPos] == 'x'){
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

					cube.transform.parent = levelHolder.transform;

					cube.transform.position = new Vector3(
						xPos + offsetX, 
						yPos + offsetY, 
						0);
				}
			}
//			Debug.Log(line);
			yPos--;
		}

		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			levelNum++;
			SceneManager.LoadScene("Week5");
		}
	}
}
