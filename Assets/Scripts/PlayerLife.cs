using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private static readonly int Death = Animator.StringToHash("Death");
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Die();
        }
    }

    private void Die()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger(Death);
    }

    private void Respawn()
    {
        Debug.Log("Respawned");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
