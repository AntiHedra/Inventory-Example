using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour {

    private Image highlight;
    private float blinkCounter = 0, blinkTime = 0.1f;
    private bool blinkTrig, blinkOn;

    private void Start() {
        highlight = transform.Find("Highlight").GetComponent<Image>();
    }

    public void Blink() {
        blinkTrig = true;
        blinkOn = true;
    }

    public void Select() {
        highlight.gameObject.SetActive(true);
    }

    public void DeSelect() {
        highlight.gameObject.SetActive(false);
    }

    private void Update() {

        if (blinkTrig == true) {

            if (blinkOn == true) {
                highlight.gameObject.SetActive(true);

                if (blinkCounter >= blinkTime) {
                    blinkOn = false;
                    blinkCounter = 0;

                } else blinkCounter += 1f * Time.deltaTime;

            } else {
                highlight.gameObject.SetActive(false);
                blinkTrig = false;
            }
        }
    }
}
