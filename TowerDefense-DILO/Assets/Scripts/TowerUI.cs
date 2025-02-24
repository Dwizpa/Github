﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _towerIcon;

    private Tower _towerPrefab;
    private Tower _currentSpawnedTower;

    public void SetTowerPrefab (Tower tower)
    {
        _towerPrefab = tower;
        _towerIcon.sprite = tower.GetTowerHeadIcon();
    }

    //Implementasi dari Interface IBeginDragHandler
    //Fungsi ini terpanggil sekali ketika pertama men-drag UI
    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject newTowerObj = Instantiate(_towerPrefab.gameObject);
        _currentSpawnedTower = newTowerObj.GetComponent<Tower>();
        _currentSpawnedTower.ToggleOrderInLayer(true);
    }

    //Implementasi dari Interface IDragHandler
    //Fungsi ini terpanggil selama men-drag UI
    public void OnDrag(PointerEventData eventData)
    {
        Camera mainCam = Camera.main;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCam.transform.position.z;
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);

        _currentSpawnedTower.transform.position = targetPos;
    }

    //Implementasi dari Interface IEndDragHandler
    //Fungsi ini terpanggil sekali ketika men-drop UI ini
    public void OnEndDrag (PointerEventData eventData)
    {
        if(_currentSpawnedTower.PlacePosition == null)
        {
            Destroy(_currentSpawnedTower.gameObject);
        }
        else
        {
            _currentSpawnedTower.LockPlacement();
            _currentSpawnedTower.ToggleOrderInLayer(false);
            LevelManager.Instance.RegisterSpawnedTower(_currentSpawnedTower);
            _currentSpawnedTower = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
