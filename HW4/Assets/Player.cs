using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator animator;
    private float movSpeed;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        movSpeed = 5;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonUp(0)) {
            this.Shoot();
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v != 0 || h != 0) {
            this.transform.Translate(movSpeed * h * Time.deltaTime, 0, movSpeed * v * Time.deltaTime, Space.World);
            animator.SetBool("Moving", true);
        }
        else {
            animator.SetBool("Moving", false);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) {
            this.transform.LookAt(hit.point);
        }
    }

    void Shoot() {
        GameObject clone = Instantiate(bullet, this.transform.position + new Vector3(1f, 0.5f, 0f), this.transform.rotation * Quaternion.Euler(0, -90, -90)) as GameObject;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * 30, ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision c) {
        if (c.transform.tag == "Bullet") {
            animator.SetTrigger("Hit");
            Destroy(this.transform.GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
