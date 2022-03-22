using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip crashSFX;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && FindObjectOfType<PlayerController>().getCanMove()) {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
