using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKaBoom : MonoBehaviour {

    public float Radio = 6f;
    public float Poder = 10f;

    public GameObject FinalText;

    public void KaBoom() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radio);

        foreach (Collider c in colliders) {
            Rigidbody rb = c.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(Poder, transform.position, Radio, 1.0f, ForceMode.Impulse);
            }
        }
        FinalText.SetActive(true);

    }
}
