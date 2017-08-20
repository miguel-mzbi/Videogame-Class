using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

	// Runs before start
	void Awake ()
    {
		print("INITIALIZING");
	}

	// Use this for initialization
	// Runs even on disabled objects
	void Start ()
    {
		print("I'm Alive!");
	}
		
	// Update is called once per frame
	// - game loop
	// - realtime application - fps 30
	// - we'll try to hit at least 60 fps

	// Update uns once per frame
	// - user input (Responsivness)
	// - motion/animation (Smoother)
	void Update ()
    {
		//print ("UPDATING");

		// Input should go here
		// Depend on the Input class
		if (Input.GetKeyDown(KeyCode.W))
        {
            print("PRESSING W");
		}
        if (Input.GetKey(KeyCode.W))
        {
            print("HOLDING W");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            print("REALEASING W");
        }
        if (Input.GetMouseButtonDown(0))
        {
            print("LEFT MOUSE BUTTON CLICKED");
        }
    }

	// Configure specific framerate
	void FixedUpdate()
    {

	}

	// Happens after update each frame
	void LateUpdate()
    {

	}
}
