using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderZone : MonoBehaviour {

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Missile" || other.transform.tag == "Brick") {
            if(other.transform.tag == "Missile") {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
