using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mono : MonoBehaviour {

    private Animator animator;
    private float life;

	// Use this for initialization
	void Start () {
        life = 100;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.X)) {
            life -= 20;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl)) {
            animator.SetTrigger("ButtonPress");
        }

        float h = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", h);
        animator.SetFloat("Life", life);
	}

    public void ActuallyDie() {
        Destroy(gameObject);
    }
}
