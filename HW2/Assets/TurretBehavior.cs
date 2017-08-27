using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {

    private float rotationSpeed;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        rotationSpeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        float v1 = -Input.GetAxis("VerticalP1");
        float v2 = -Input.GetAxis("VerticalP2");

        if(Input.GetAxis("VerticalP1") != 0 && this.transform.name == "CannonPivotBlue") {
            this.transform.Rotate(0, 0, rotationSpeed * v1 * Time.deltaTime);
        }
        if(Input.GetAxis("VerticalP2") != 0 && this.transform.name == "CannonPivotRed") {
            this.transform.Rotate(0, 0, rotationSpeed * v2 * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space) && this.transform.name == "CannonPivotBlue") {
            GameObject bulletB = Instantiate(bullet, transform.GetChild(0).position, transform.rotation) as GameObject;
            bulletB.GetComponentInChildren<BulletBehavior>().SetParentTank(this.transform.parent.name);
            Rigidbody RigidbodyBulletB = bulletB.GetComponent<Rigidbody>();

        }
        if (Input.GetKeyDown(KeyCode.RightControl) && this.transform.name == "CannonPivotRed") {
            GameObject bulletA = Instantiate(bullet, transform.GetChild(0).position, transform.rotation) as GameObject;
            bulletA.GetComponentInChildren<BulletBehavior>().SetParentTank(this.transform.parent.name);
            Rigidbody RigidbodyBulletA = bulletA.GetComponent<Rigidbody>();
        }
    }
}
