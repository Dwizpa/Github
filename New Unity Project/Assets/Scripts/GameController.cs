﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public List<Birds> Birds;
    public List<Enemy> Enemies;
    public TrailController trail;
    public BoxCollider2D TapCollider;
    private Birds _shotBird;

    private bool _isGameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroyed += ChangeBird;
            Birds[i].OnBirdShot += AssignTrail;
        }

        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroyed += CheckGameEnd;
        }

        TapCollider.enabled = false;
        SlingShooter.InitiateBird(Birds[0]);
        _shotBird = Birds[0];
    }

    public void ChangeBird()
    {
        TapCollider.enabled = false;
        if(_isGameEnded)
        {
            return;
        }
        Birds.RemoveAt(0);

        if(Birds.Count > 0)
            SlingShooter.InitiateBird(Birds[0]);
    }

    public void CheckGameEnd(GameObject destroyedEnemy)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i].gameObject == destroyedEnemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }

        if(Enemies.Count == 0)
        {
            _isGameEnded = true;
        }
    }

    public void AssignTrail(Birds birds)
    {
        trail.SetBird(birds);
        StartCoroutine(trail.SpawnTrail());
        TapCollider.enabled = true;
    }

    void OnMouseUp()
    {
        if(_shotBird != null)
        {
            _shotBird.OnTap();
        }
    }
}
