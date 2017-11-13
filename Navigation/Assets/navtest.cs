using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navtest : MonoBehaviour {

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = new Vector3(2.5f, 2.6f, 7.7f);
	}
	
	// Update is called once per frame
	void Update () {
        Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(rayito, out hit)) {
            agent.destination = hit.point;
        }
	}
}
