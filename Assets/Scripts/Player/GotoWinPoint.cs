using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GotoWinPoint : MonoBehaviour
{
    [SerializeField] Transform End;
    private const string PlayerTag = "Player";

    private void Start()
    {
        PlayerMovement.instance.SetEndPoint(End.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(PlayerTag)){

            PlayerMovement.instance.MoveToWinPoint(End.transform.position);
        }
    }
}
