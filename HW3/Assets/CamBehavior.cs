using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour {

    public GameObject player;
    private float cameraHeight = 15.0f;

    void Update() {
        Vector3 pos = player.transform.position;
        pos.z += -10;
        pos.y += 15;
        this.transform.position = pos;
    }
}
