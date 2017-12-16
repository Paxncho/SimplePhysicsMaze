using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearFloor : MonoBehaviour {

    public float AnimationTime = 5f;
    public float ReappearingTime = 10f;

    public bool AnimationByScript = false;
    public Material transparentMaterial;

    Material originalMaterial;
    Animator animator;
    MeshRenderer render;

	void Start () {
        animator = GetComponent<Animator>();
        
        if (AnimationByScript && animator != null) {
            animator.enabled = false;
        }

        render = GetComponent<MeshRenderer>();
        originalMaterial = render.material;
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            ActivateTrap();
        }
    }

    void ActivateTrap() {
        if (AnimationByScript)
            StartCoroutine(Animation());
        else {
            animator.SetBool("Active", true);
            Invoke("Dissapear", AnimationTime);
        }
    }

    void Dissapear() {
        if (AnimationByScript)
            StopCoroutine(Animation());
        else
            animator.SetBool("Active", false);

        render.material = originalMaterial;
        gameObject.SetActive(false);
        Invoke("Reappear", ReappearingTime);
    }

    void Reappear() {
        gameObject.SetActive(true);
    }

    IEnumerator Animation() {
        float initialTime = Time.time;
        float dt = Time.time - initialTime;

        bool dissapear = false;
        do {
            if (!dissapear) {
                render.material = transparentMaterial;
                dissapear = true;
            } else {
                render.material = originalMaterial;
                dissapear = false;
            }

            yield return new WaitForSeconds((1f/6f));
            dt = Time.time - initialTime;
        } while (dt < AnimationTime);

        Dissapear();
    }
}
