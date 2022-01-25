using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 1f;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position,
            Time.deltaTime * speed);
    }
}
