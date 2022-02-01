using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryFanfare : MonoBehaviour
{

    [SerializeField] private GameObject[] emitterPositions;
    [SerializeField] private GameObject victoryEmitter;
    private bool didPlayerEnter = false;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Victory");
        if (other.CompareTag("Player") && !didPlayerEnter)
        {
            foreach (var pos in emitterPositions)
            {
                Instantiate(victoryEmitter, pos.transform.position, pos.transform.rotation);
            }

            didPlayerEnter = true;
        }
    }
}
