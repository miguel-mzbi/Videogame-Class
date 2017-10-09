
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {

    private Animator animator;
    public GameObject victim;
    public GameObject bullet;
    private Vector3 min;
    private Vector3 max;
    private Vector3 newPosition;
    private float prevShoot;
    private float threshold;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        this.min = new Vector3(-17f, 5.51f, 17f);
        this.max = new Vector3(1f, 5.51f, 19f);
        this.prevShoot = Time.time;
        this.newPosition = this.transform.position;
        this.threshold = 1;
        transform.LookAt(victim.transform);
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time - this.prevShoot >= 3) {
            this.prevShoot = Time.time;

            float valueX = Random.Range(-20f, 2f);
            float valueZ = Random.Range(15f, 20f);
            this.newPosition = new Vector3(Mathf.Clamp(valueX, this.min.x, this.max.x), 5.51f, Mathf.Clamp(valueZ, this.min.z, this.max.z));

            this.Shoot();
            StartCoroutine("Move");
        }
        else if(Vector3.Distance(this.transform.position, this.newPosition) < this.threshold) {
            StopAllCoroutines();
            this.animator.SetBool("Moving", false);
            transform.LookAt(victim.transform);
        }
        
    }

    void Shoot() {
        GameObject clone = Instantiate(bullet, this.transform.position + new Vector3(0f, 1f, 0f), this.transform.rotation * Quaternion.Euler(0, -90, -90)) as GameObject;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * 30, ForceMode.Impulse);

    }

    IEnumerator Move() {
        this.animator.SetBool("Moving", true);
        while (true) {
            this.transform.LookAt(newPosition);
            this.transform.Translate(new Vector3(0, 0, 1f) * Time.deltaTime * 6);
            yield return null;
        }
    }
}
