using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<GameObject> levelPrefabs = new List<GameObject>();

    private int currentLevelID;
    private GameObject currentLevel;
    
    #region Unity Functions

    private void Start()
    {
        DataManager.Instance.OnDataChanged += OnDataChanged;
    }

    #endregion

    #region Event Functions

    private void OnDataChanged(DataType dataType, int value)
    {
        if(dataType == DataType.Level)
        {
            LoadLevel(value);
        }
    }

    #endregion

    #region Other Functions

    private void LoadLevel(int id)
    {
        currentLevelID = id;

        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        
        currentLevel = Instantiate(levelPrefabs[id - 1], transform);
    }

    #endregion
}
