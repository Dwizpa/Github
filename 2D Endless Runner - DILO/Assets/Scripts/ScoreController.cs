using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int currentScore = 0;

    [Header("Score Highlight")]
    public int scoreHighlight;
    public CharacterSoundController sound;

    private int lastScoreHighlight = 0;
    // Start is called before the first frame update
    void Start()
    {
        //reset
        currentScore = 0;
        lastScoreHighlight = 0;
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void IncreaseCurrentScore(int increment)
    {
        currentScore += increment;

        if(currentScore - lastScoreHighlight > scoreHighlight)
        {
            sound.PlayScoreHighlight();
            lastScoreHighlight += scoreHighlight;
        }
    }

    public void FinishScoring()
    {
        //set high score
        if(currentScore > ScoreData.highScore)
        {
            ScoreData.highScore = currentScore;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
