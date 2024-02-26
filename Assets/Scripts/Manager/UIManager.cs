using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text coinText;
    [SerializeField] private Text levelText;
    [SerializeField] private List<GameObject> panels;

    #region Unity Functions

    private void Start()
    {
        HidePanel(1);
        
        GameManager.Instance.OnEventEmitted += OnEventEmitted;
        DataManager.Instance.OnDataChanged += OnDataChanged;
    }

    #endregion

    #region Event Functions

    private void OnEventEmitted(EventID eventId)
    {
        switch (eventId)
        {
            case EventID.OnCompleteLevel:
                StartCoroutine(ShowWinPopup());
                break;
            case EventID.OnNextLevel:
                HideWinPopup();
                break;
        }
    }
    private void OnDataChanged(DataType dataType, int value)
    {
        switch (dataType)
        {
            case DataType.Coin:
                SetCoinInfor(value);
                break;
            case DataType.Level:
                SetLevelInfor(value);
                break;            
        }
    }

    #endregion

    #region Other Functions

    private void ShowPanel(int index)
    {
        panels[index].SetActive(true);
    }

    private void HidePanel(int index)
    { 
        panels[index].SetActive(false);
    }

    private IEnumerator ShowWinPopup()
    {
        yield return new WaitForSeconds(5f);
        ShowPanel(1);
        //SoundManager.Instance.Play(SoundType.OpenUI);
    }
    
    private void HideWinPopup()
    {
        HidePanel(1);
    }
    
    public void SetCoinInfor(int coin)
    {
        coinText.text = coin.ToString();
    }
    
    public void SetLevelInfor(int level)
    {
        levelText.text = "Level " + level;
    }

    #endregion
}
