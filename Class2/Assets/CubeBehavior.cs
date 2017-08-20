using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour {

    public float x;
    public float speed;

	// Use this for initialization
	void Start () {
        x = 0;
        speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            x = (x + 0.1f) % (2 * Mathf.PI);
        }

        transform.Translate(h * 0.5f * speed * Time.deltaTime,
                        v * Mathf.Sin(x) * speed * Time.deltaTime,
                        0);

        /*transform.Translate(h * speed * Time.deltaTime,
                            v * speed * Time.deltaTime,
                            0);*/

        // Time.deltaTime
        // - the amount of time in seconds between the last frame and the current one the current one
    }

    void OnCollisionEnter(Collision c) {
        print("I hit that");
    }

    void OnCollisionStay(Collision c) {
        print("I'm hittin that " + c.transform.name);
    }

    void OnCollisionExit(Collision c) {
        print("I hote that");
    }
}
