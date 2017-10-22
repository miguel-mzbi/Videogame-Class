using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint[] neighbors;

    void OnDrawGizmos() {

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, .5f);
        Gizmos.color = Color.yellow;

        foreach(Waypoint wp in this.neighbors) {

            Gizmos.DrawLine(this.transform.position, wp.transform.position);

        }
    }

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .5f);

    }
}
