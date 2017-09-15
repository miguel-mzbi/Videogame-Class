using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public Waypoint[] path;
    public float threshold;

    private int current;

    void Start() {
        current = 0;
        threshold = 1;
    }

    void Update() {

        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 3, Space.World);

        float distance = Vector3.Distance(transform.position, path[current].transform.position);

        if(distance < threshold) {

            current++;
            current %= path.Length;
        }
    }
}
