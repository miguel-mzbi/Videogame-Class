using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour {

    public Transform victim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(victim);
        transform.Translate(transform.forward * Time.deltaTime * 2, Space.World);
	}
}
