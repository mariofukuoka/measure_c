using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestructible : MonoBehaviour
{
    [SerializeField] private float destructionTime;
    void Start()
    {
        Invoke(nameof(AutoDestroy), destructionTime);
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }
    
}
