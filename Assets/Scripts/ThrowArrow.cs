using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArrow : MonoBehaviour {

    public GameObject Arrow;
    public Transform container;
    public float secondsToThrow;

    public bool active = false;
    float lastArrowShooted = 0;

    void Start() {
        StartCoroutine(CheckForPlayer());
    }

    void FixedUpdate() {
        if (active) {
            if (Time.time - lastArrowShooted >= secondsToThrow) {
                ObjectPool.Instantiate(Arrow, transform.position, Arrow.transform.rotation, container);
                print("THORWING");
                lastArrowShooted = Time.time;
            }
        }
    }

    public void DeactiveShooting() {
        active = false;
        StopAllCoroutines();
        StartCoroutine(CheckForPlayer());
    }

    IEnumerator CheckForPlayer() {
        while (!active) {
            yield return new WaitForFixedUpdate();

            Debug.DrawRay(transform.position, -transform.right, Color.cyan, 1);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.right, 10);
            foreach(RaycastHit hit in hits) {
                if (hit.transform.CompareTag("Player")) {
                    active = true;
                }
            }
        }
    }
}
