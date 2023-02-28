using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] private Button ReloadBtn;

    private void OnEnable()
    {
        ReloadBtn.onClick.AddListener(ReloadSceneBtnOnClick);
    }

    private void OnDisable()
    {
        ReloadBtn.onClick.RemoveListener(ReloadSceneBtnOnClick);
    }

    private void ReloadSceneBtnOnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
