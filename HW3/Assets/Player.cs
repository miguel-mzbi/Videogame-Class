using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator animator;
    private float movSpeed;

	// Use this for initialization
	void Start () {
        movSpeed = 5;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v != 0 || h != 0) {
            this.transform.Translate(movSpeed * h * Time.deltaTime, 0, movSpeed * v * Time.deltaTime);
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

    void OnCollisionEnter(Collision c) {
        if (c.transform.tag == "Bullet") {
            animator.SetTrigger("Hit");
            Destroy(this.transform.GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
