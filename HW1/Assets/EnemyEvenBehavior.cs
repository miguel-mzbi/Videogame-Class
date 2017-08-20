using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvenBehavior : MonoBehaviour {

    private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
        _startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = _startPosition + new Vector3(-Mathf.Cos(Time.time - Mathf.PI/2) * Time.deltaTime * 1000, 0f, 0f);
    }
}
