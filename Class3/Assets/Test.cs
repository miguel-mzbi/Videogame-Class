using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Waypoint a;
    public Waypoint b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Return)) {

            List<Waypoint> bw = Pathfinding.BreadthWise(a, b);
            for (int i = 0; i < bw.Count; i++) {
                print("BreadthWise: " + bw[i].transform.name);
            }
            List<Waypoint> dw = Pathfinding.DepthWise(a, b);
            for (int i = 0; i < dw.Count; i++) {
                print("DepthWise: " + dw[i].transform.name);
            }
            List<Waypoint> aStar = Pathfinding.AStar(a, b);       
            for (int i = 0; i < aStar.Count; i++) {
                print("AStar: " + aStar[i].transform.name);
            }
        }
	}
}
