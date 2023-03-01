using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusBall : MonoBehaviour
{
    [SerializeField] private Transform ballCollections;
    [SerializeField] private Transform stickMan;
    private void OnCollisionEnter(Collision collision)
    {
        if (ballCollections.childCount == 1)
        {
            GamePlayControll.instance.GameOver();
            return;
        }
        Debug.Log("collided");
        ballCollections.GetChild(ballCollections.childCount-1).SetParent(null);
    }
}
