using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Project_2;
using TMPro;
using UnityEngine.AI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitGameButton;
    private void Awake()
    {

        _quitGameButton.onClick.AddListener(() => { Application.Quit(); });
        _startGameButton.onClick.AddListener(StartGame);

    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }
}
