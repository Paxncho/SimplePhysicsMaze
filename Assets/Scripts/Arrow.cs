using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float timeToKill = 10;
    public float speed = 5;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Invoke("KillArrow", timeToKill);

        rb.AddForce(-transform.right * speed, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.SendMessage("BackToCheckpoint");

            transform.parent.parent.SendMessage("DeactiveShooting");
        }
    }

    void KillArrow() {
        gameObject.SetActive(false);
    }
}
