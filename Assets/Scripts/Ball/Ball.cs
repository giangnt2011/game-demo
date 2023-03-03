using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool hasCollide = false;
    public bool broken = false;
    [SerializeField] private GameObject ballExplosionPrefab;
    AudioSource audioSource;
    [SerializeField] private Transform ObjectPollTransform;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasCollide = true;
        }
    }
}
