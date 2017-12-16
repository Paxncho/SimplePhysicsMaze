using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public GameObject gate;
    
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gate.SetActive(false);

            transform.parent.gameObject.SetActive(false);
        }
    }
}
