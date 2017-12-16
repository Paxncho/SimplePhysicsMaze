using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviour {

    public Canvas gameOverCanvas;
    public Renderer render;

    public string gameOverMessage;

    Vector3 CheckPoint;
    Rigidbody rb;
    SimpleCharacterControl control;
    Text gameOverText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        control = GetComponent<SimpleCharacterControl>();
        gameOverText = gameOverCanvas.gameObject.GetComponentInChildren<Text>();
        gameOverCanvas.enabled = false;
    }

    public void SaveCheckPoint(Vector3 newPos) {
        CheckPoint = newPos;
    }

    public void BackToCheckpoint() {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver() {
        control.enabled = false;
        render.enabled = false;
        gameOverCanvas.enabled = true;

        int secondsLeft = 5;
        while (secondsLeft > 0) {
            gameOverText.text = gameOverMessage + "\n" + secondsLeft;
            yield return new WaitForSeconds(1);
            secondsLeft--;
        }

        yield return new WaitForFixedUpdate();

        gameOverCanvas.enabled = false;
        rb.position = CheckPoint;
        control.enabled = true;
        render.enabled = true;
    }
}
