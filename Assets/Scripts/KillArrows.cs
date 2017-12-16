using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArrows : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        other.gameObject.SendMessage("KillArrow");
    }
}
