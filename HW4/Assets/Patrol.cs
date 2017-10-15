using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    private int lives;
    private Animator animator;
    public Waypoint[] path;
    private float threshold;
    public int current;

    void Start() {
        this.lives = 3;
        this.threshold = 1;
        animator = GetComponent<Animator>();
    }

    void Update() {

        this.transform.LookAt(this.path[current].transform);
        this.transform.Translate(this.transform.forward * Time.deltaTime * 5, Space.World);

        float distance = Vector3.Distance(this.transform.position, this.path[current].transform.position);

        if (distance < this.threshold) {

            current++;
            current %= path.Length;
        }
    }

    void OnTriggerEnter(Collider c) {
        if(c.transform.tag == "Bullet") {
            this.lives--;
            animator.SetInteger("Lives", this.lives);
            animator.SetTrigger("Hit");
            print("Hittedted");
            if(lives == 0) {
                animator.SetBool("Died", true);
                Destroy(this);
            }
        }
    }
}
