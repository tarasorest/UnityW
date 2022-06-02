using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu_2 : MonoBehaviour
{
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _quitGameButton;

    private void Awake()
    {
        _restartGameButton.onClick.AddListener(StartGame);
        _quitGameButton.onClick.AddListener(FinishGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }
    public void FinishGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
