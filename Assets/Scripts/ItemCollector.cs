using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int collectibleCount = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollectibleItem"))
        {
            collectibleCount++;
            Debug.Log("Collected " + collectibleCount + " items");
            if ($"Score: {collectibleCount}" != text.text)
            {
                text.text = $"Score: {collectibleCount}";
            }
            Destroy(other.gameObject);
        }
    }
}
