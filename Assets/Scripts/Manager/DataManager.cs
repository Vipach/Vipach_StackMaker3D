using System;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public event Action<DataType, int> OnDataChanged;
    public int coins { get; private set; }
    public int level { get; private set; }
    
    #region Unity Functions
    
    protected override void Awake()
    {
        base.Awake();
        
        coins = PlayerPrefs.GetInt("Coins", 0);
        level = PlayerPrefs.GetInt("Level", 1);
    }

    private void Start()
    {
        GameManager.Instance.OnEventEmitted += OnEventEmitted;
        
        SetData(DataType.Coin, coins);
        SetData(DataType.Level, level);
    }

    #endregion

    #region Event Functions

    private void OnEventEmitted(EventID eventID)
    {
        switch (eventID)
        {
            case EventID.OnNextLevel:
                SetData(DataType.Level, GetNextLevel(level));
                break;
            case EventID.OnResetLevel:
                SetData(DataType.Level, level);
                break;
        }
    }

    #endregion
    
    #region Other Functions
    private void SetCoin (int value)
    {
        coins = value;
        
        PlayerPrefs.SetInt("Coins", coins);
    }
    
    private void SetLevel (int value)
    {
        level = value;

        PlayerPrefs.SetInt("Level", level);
    }
    
    private int GetNextLevel(int currentLevel)
    {
        if(currentLevel + 1 > Constants.MAX_LEVEL)
        {
            return 1;
        }
        
        return currentLevel + 1;
    }
    
    public void SetData(DataType dataType, int value)
    {
        switch (dataType)
        {
            case DataType.Coin:
                SetCoin(value);
                break;
            case DataType.Level:
                SetLevel(value);
                break;
        }

        OnDataChanged?.Invoke(dataType, value);
    }
    
    public void OnClickNoThanksBtn()
    {
        SetData(DataType.Coin, coins + Constants.COIN_PER_LEVEL);
    }
    
    public void OnClickCTABtn()
    {
        SetData(DataType.Coin, coins + Constants.COIN_PER_ADS);
    }

    #endregion
}
