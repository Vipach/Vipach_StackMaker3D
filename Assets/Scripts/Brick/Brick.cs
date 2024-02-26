using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Transform brickOnTop;
    private bool hasTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (hasTrigger)
        {
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            //SoundManager.Instance.Play(SoundType.GetBrick);
            
            other.GetComponent<Player>().AddBrick();
            brickOnTop.gameObject.SetActive(false);
            hasTrigger = true;
        }
    }
}
