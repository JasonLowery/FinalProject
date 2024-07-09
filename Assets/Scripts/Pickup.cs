using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Pickup : MonoBehaviour
{
    //step 1, detect collision
    //step 2, Identify obj colliding with this
    //step 3, destroy if obj collides with player

    public int pointValue = 1;

    private void OnTriggerEnter (Collider other) //Function called when this collider collides with an obj marked as trigger

    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject); //destroy coin
            GameManager.Instance.UpdateScore(pointValue); //tell GameManager to update score by 1
            GameManager.Instance.TotalPickups -= 1; //increase score when you picked up
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 90) * Time.deltaTime);
    }
}
