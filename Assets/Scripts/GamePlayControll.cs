using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayControll : MonoBehaviour
{
    public static GamePlayControll instance;
    
    public void GameOver()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
