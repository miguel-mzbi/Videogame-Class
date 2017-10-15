using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint[] adjacents;


    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
        Gizmos.color = Color.red;
        for(int i = 0; i < this.adjacents.Length; i++) {
            Gizmos.DrawLine(this.transform.position, this.adjacents[i].transform.position);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
    }
}
