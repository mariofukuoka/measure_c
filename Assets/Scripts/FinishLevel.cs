using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.name == "Player" && !levelFinished)
        {
            finishSound.Play();
            Invoke(nameof(CompleteLevel), 2f);
            other.attachedRigidbody.bodyType = RigidbodyType2D.Static;
            levelFinished = true;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
