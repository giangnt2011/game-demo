using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset = new Vector3(-11.6f, 5.24f, -5f);

    private void LateUpdate()
    {
        if (player)
        {
            this.transform.position = player.transform.position + offset;
        }
    }
}
