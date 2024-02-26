using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] private GameObject chessOpen;
    [SerializeField] private GameObject chessClose;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenChest();
            GameManager.Instance.EmitCompleteLevelEvent();
        }
    }

    private void OpenChest()
    {
        chessOpen.SetActive(true);
        chessClose.SetActive(false);
        //SoundManager.Instance.Play(SoundType.OpenChest);
    }
}
