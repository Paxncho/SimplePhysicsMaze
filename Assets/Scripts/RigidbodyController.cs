using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour {

    public float moveSpeed = 10f;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        Transform cTransform = Camera.main.transform;

        Vector3 zForce = cTransform.forward * Input.GetAxis("Vertical") * moveSpeed;
        Vector3 xForce = cTransform.right * Input.GetAxis("Horizontal") * moveSpeed;

        rb.AddForce(zForce + xForce);
        print("Z: " + zForce + " X: " + xForce);
    }
}
