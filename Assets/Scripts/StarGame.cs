﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StarGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) {
            SceneManager.LoadScene("InfiniteRunner");
            
        }
	
	}
}