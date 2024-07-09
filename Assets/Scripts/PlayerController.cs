using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    
    public float moveSpeed = 5f;

    private Vector3 moveDirections = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput,0, verticalInput); 

        controller.Move(movement *moveSpeed* Time.deltaTime);
    }
}
