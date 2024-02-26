using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
    [SerializeField] private Material lastBrickMaterial;
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
            
            other.GetComponent<Player>().RemoveBrick();
            GetComponent<MeshRenderer>().material = lastBrickMaterial;
            hasTrigger = true;
        }
    }
}
