using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPass : MonoBehaviour
{
    [SerializeField] private bool soundTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(soundTrigger)
            {
                AudioManager.Instance.PlaySound("AirPass");
            }
        }
    }
}