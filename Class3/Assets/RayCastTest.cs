using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Raycast - shooting a ray from a vector
        // Using for picking
        // Used in FPS

        // THIS IS SLOW FOR CALCULATIONS

        if(Input.GetMouseButtonUp(0)) {
            // Ray from mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                print(hit.transform.name + " " + hit.point);
            }
        }
	}
}
