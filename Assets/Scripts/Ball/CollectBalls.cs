using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBalls : MonoBehaviour
{
    [SerializeField] private Transform BallCollections;
    [SerializeField] private Transform ObjectPoll;
    [SerializeField] private Transform StickManTransform;
    [SerializeField] private Rigidbody Player;
    private string Ball_1_Tag = "ball1";
    private string Wall = "wall";
    //private string Ball_3_Tag = "ball3";


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Ball_1_Tag))
        {
            other.gameObject.TryGetComponent<Ball>(out var ball);
            if (!ball.hasCollide)
            {
                SetStickManTransform(1, StickManTransform);
                for (int i = 0; i < BallCollections.childCount; i++)
                {
                    LiftPlayer(BallCollections.GetChild(i), 1);
                }


                SetNewBall(other.gameObject.transform.parent.transform);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Wall))
        {
            collision.gameObject.TryGetComponent<Wall>(out var Wall);
            if (!Wall.hasCollide)
            {

                SetMinusBall(BallCollections.GetChild(BallCollections.childCount - 1));
                for (int i = 0; i < BallCollections.childCount; i++)
                {
                    LiftPlayer(BallCollections.GetChild(i), -1);
                }
                SetStickManTransform(-1, StickManTransform);
                //Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.3f, Player.transform.position.z + 0.2f);
                Player.transform.position = new Vector3(Player.transform.position.x, 1.2f, Player.transform.position.z + 0.4f);
            }
        }
    }

    private void SetStickManTransform(int value, Transform StickManTransform)
    {
        StickManTransform.position = new Vector3(StickManTransform.position.x, StickManTransform.position.y + value, StickManTransform.position.z);
    }
    private void LiftPlayer(Transform trans, int ball)
    {
        trans.localPosition = new Vector3(0, trans.localPosition.y + ball, 0);
    }
    private void SetNewBall(Transform trans)
    {
        trans.SetParent(BallCollections, true);
        trans.localPosition = Vector3.zero;
    }
    private void SetMinusBall(Transform trans)
    {
        trans.SetParent(ObjectPoll, true);
        trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z -0.2f);
    }
}
