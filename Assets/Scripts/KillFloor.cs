using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour {

    public bool killByTrigger;
    public bool killByCollision;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
            if (killByCollision)
                collision.gameObject.SendMessage("BackToCheckpoint");
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (killByTrigger)
                other.gameObject.SendMessage("BackToCheckpoint");
        }
    }
}
