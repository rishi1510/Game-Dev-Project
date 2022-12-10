using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public AudioSource audioSource;

    void playSound() {
        audioSource.Play();
    }
}
