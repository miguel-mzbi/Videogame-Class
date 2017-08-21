using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public float speed;
    public GameObject original;

	// Use this for initialization
	void Start () {

        speed = 1;
        // Way to retrieve a reference
	}
	
	// Update is called once per frame
	void Update () {

        float h = -Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        transform.Translate(speed * h * Time.deltaTime, 0, 0, Space.Self);
        transform.Rotate(speed * v, 0, 0);

        if(Input.GetKeyUp(KeyCode.Space)) {

            // Quaternion
            // 4 value vector
            // Describe rotation in 3d space
            GameObject clone = Instantiate(original, transform.position, transform.rotation) as GameObject;
            Rigidbody rb2 = clone.GetComponent<Rigidbody>();
        }
	}
}
