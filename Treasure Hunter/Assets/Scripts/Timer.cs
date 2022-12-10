using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer, seconds, minutes;
    public string text;
    public bool stopTimer = false;

    void Start() {
        timer = 0f;
        seconds = 0f;
        minutes = 0f;
        text = "00:00";
        GetComponent<TextMeshProUGUI>().SetText(text);
        stopTimer = false;

        StartCoroutine(runTimer());
    }

    IEnumerator runTimer() {
        yield return new WaitForSeconds(1);

        if(stopTimer == false) {
            timer ++;
            seconds ++;

            if(seconds >= 60) {
                seconds = 0;
                minutes++;
            }

            text = "";
            if(minutes < 10) {
                text = "0" + minutes.ToString();
            }
            else {
                text = minutes.ToString();
            }

            text += ":";

            if(seconds < 10) {
                text += "0" + seconds.ToString();
            }
            else {
                text += seconds.ToString();
            }

            GetComponent<TextMeshProUGUI>().SetText(text);
        }

        StartCoroutine(runTimer());
    }
}
