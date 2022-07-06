using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Menu3 : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    private void Awake()
    {
        _startGameButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }
}
