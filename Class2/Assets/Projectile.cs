using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Rigidbody rb;
    private static GameObject instance;

    // Property
    // Better accssor methods
    public static GameObject Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        instance = this.gameObject;
    }

	// Use this for initialization
	void Start () {

        // Retrieve reference
        rb = GetComponent<Rigidbody>();
        // Up, right and forward
        // These vectors are always unit vector
        rb.AddForce(transform.up*50, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
