using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private GameObject collectionParticles;

    private int colletibleCount = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollectibleItem"))
        {
            collectionSoundEffect.Play();
            colletibleCount++;
            Debug.Log("Collected " + colletibleCount + " items");
            if ($"Score: {colletibleCount}" != text.text)
            {
                text.text = $"Score: {colletibleCount}";
            }
            Destroy(other.gameObject);
            Instantiate(collectionParticles, transform.position, transform.rotation);
        }
    }
}
