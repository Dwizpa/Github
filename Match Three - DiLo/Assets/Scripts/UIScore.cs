﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text highScore;
    public Text currenScore;

    private void Update()
    {
        highScore.text = ScoreManager.instance.HighScore.ToString();
        currenScore.text = ScoreManager.instance.CurrentScore.ToString();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
