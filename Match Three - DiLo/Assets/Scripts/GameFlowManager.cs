﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{

    #region Singleton

    private static GameFlowManager _instance = null;

    public static GameFlowManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameFlowManager>();
            }
            if(_instance == null)
            {
                Debug.LogError("Fatal Error: GameFlowManager not Found");
            }
            return _instance;
        }
    }

    #endregion

    public bool IsGameOver { get { return isGameOver;}}
    private bool isGameOver = false;

    [Header("UI")]
    public UIGameOver GameOverUI;

    
    // Start is called before the first frame update
    private void Start()
    {
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        ScoreManager.instance.SetHighScore();
        GameOverUI.Show();
    }
}
