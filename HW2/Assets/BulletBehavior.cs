using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private Rigidbody rb;
    private int brickCount;
    private string parentTank;
    private static GameObject instance;

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
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 13, ForceMode.Impulse);
        brickCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void SetParentTank(string pt) {
        this.parentTank = pt;
    }

    void OnCollisionEnter(Collision c) {
        if (c.transform.tag == "Brick") {
            Destroy(c.gameObject);
            brickCount++;

            if(brickCount > 2) {
                Destroy(this.gameObject.transform.parent.gameObject);
                Destroy(this.gameObject);
            }   
        }
        else if (c.transform.tag == "Player" && c.transform.name != this.parentTank) {
            Destroy(c.gameObject);
            Destroy(this.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
