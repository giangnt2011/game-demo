using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float yaxis;
    private Vector3 offset;

    private Camera cam;
    public float zoomMax = 20.0f;      // Giá trị zoom tối đa
    public float zoomMin = 5.0f;       // Giá trị zoom tối thiểu
    public float zoomSpeed = 1.0f;

    private void Awake()
    {
        offset = player.transform.position - transform.position;
    }

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (player)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position - offset, 0.1f);
            //this.transform.position = player.transform.position - offset;
            //yaxis = player.transform.position.y;
        }
    }

}
