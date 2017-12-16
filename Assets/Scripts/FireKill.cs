using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKill : MonoBehaviour {

    public float SecondsToKill = 2;

    float initialTimeTouch;

    bool Check() {
        return Time.time - initialTimeTouch >= SecondsToKill;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            initialTimeTouch = Time.time;
        }
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
            if (Check())
                collision.gameObject.SendMessage("BackToCheckpoint");
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
            if (Check())
                collision.gameObject.SendMessage("BackToCheckpoint");
    }
}
