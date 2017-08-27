using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehavior : MonoBehaviour {

    private float movSpeed;

	// Use this for initialization
	void Start () {
        movSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        float h1 = -Input.GetAxis("HorizontalP1");
        float h2 = -Input.GetAxis("HorizontalP2");

        if (Input.GetAxis("HorizontalP1") != 0 && this.transform.name == "BlueTank") {
            this.transform.Translate(movSpeed * h1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetAxis("HorizontalP2") != 0 && this.transform.name == "RedTank") {
            this.transform.Translate(-movSpeed * h2 * Time.deltaTime, 0, 0);
        }
    }
}
