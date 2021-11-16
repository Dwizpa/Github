using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton

    private static SoundManager _instance = null;

    public static SoundManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if(_instance == null)
                {
                    Debug.LogError("Fatal Error: SoundManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    public AudioClip scoreNormal;
    public AudioClip scoreCombo;

    public AudioClip wrongMove;
    public AudioClip tap;
    private AudioSource Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<AudioSource>();
    }

    public void PlayScore(bool isCombo)
    {
        if(isCombo)
        {
            Player.PlayOneShot(scoreCombo);
        }
        else
        {
            Player.PlayOneShot(scoreNormal);
        }
    }

    public void PlayWrong()
    {
        Player.PlayOneShot(wrongMove);
    }

    public void PlayTap()
    {
        Player.PlayOneShot(tap);
    }
}
