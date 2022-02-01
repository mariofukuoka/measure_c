using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimedTrap : MonoBehaviour
{
    [SerializeField] private float delay;

    [SerializeField] private float initialDelay;
    // Start is called before the first frame update
    [SerializeField] private AnimationClip animationClip;
    private Animator animator;
    
    private static readonly int Fire = Animator.StringToHash("Fire");
    private bool isOnFire = false;
    private static readonly int IsOnFire = Animator.StringToHash("isOnFire");

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating(nameof(TransitionState), initialDelay, animationClip.length + delay);
    }

    void TransitionState()
    {
        isOnFire = !isOnFire;
        animator.SetBool(IsOnFire, isOnFire);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isOnFire && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerLife>().Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
