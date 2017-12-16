using UnityEngine;
using System.Collections;

public class TriggerKaBoom : MonoBehaviour {

    public FinalKaBoom kaboom;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            kaboom.KaBoom();
    }
}
