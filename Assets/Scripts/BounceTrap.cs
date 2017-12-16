using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTrap : MonoBehaviour {

    public float JumpForce;
    public int SecondsDisabled;

    bool active;
    float lastJumpTime;

	// Use this for initialization
	void Start () {
        lastJumpTime = Time.time - SecondsDisabled;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastJumpTime >= SecondsDisabled)
            active = true;
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player") && active) {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(JumpForce * Vector3.up, ForceMode.Impulse);
            active = false;
            lastJumpTime = Time.time;
        }
    }
}
