using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    void OnCollisionEnter(Collision c) {
        Destroy(this.gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider c) {
        Destroy(this.gameObject);
    }
}
