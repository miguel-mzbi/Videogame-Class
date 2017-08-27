using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private Rigidbody rb;
    private int brickCount;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 13, ForceMode.Impulse);
        brickCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter(Collision c) {
        if(c.transform.tag == "Brick" && brickCount <= 2) {
            Destroy(c.gameObject);
            brickCount++;
        }
        else {
            print("Destroying");
            Destroy(this.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);

        }
        if (c.transform.tag == "Player") {
            print("Destroying tank");
            Destroy(c.gameObject);
        }
    }
}
