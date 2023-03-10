using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCellecter : MonoBehaviour
{
    [SerializeField] private Text Score;
    private int CoinScore=0;

    private void Start()
    {
        Score.text = "0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.TryGetComponent<Coin>(out var coin);
            if(coin.hasCollided)
            {
                CoinScore++;
                Score.text = CoinScore.ToString();
            }
        }
    }
}
