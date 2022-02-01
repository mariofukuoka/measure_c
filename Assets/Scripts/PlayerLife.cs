using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour, IDamageable
{
    private Animator animator;
    private static readonly int Death = Animator.StringToHash("Death");
    private Rigidbody2D rigidBody;
    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes") || other.gameObject.CompareTag("KillPlane"))
        {
            Die();
        }
    }

    public void Die()
    {
        deathSoundEffect.Play();
        rigidBody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger(Death);
    }

    private void Respawn()
    {
        Debug.Log("Respawned");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnDamage(float damageAmount, GameObject damageSource)
    {
        Debug.Log($"Received {damageAmount} from source {gameObject.name}");
    }
}
