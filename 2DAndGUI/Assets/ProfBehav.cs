using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfBehav : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        animator.SetFloat("vertical", v);

        if(v != 0) {
            this.transform.Translate(this.transform.up * Time.deltaTime * v);
        }
	}
}
