using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraTransform;
    private CharacterController controller;
    public LayerMask groundLayer;
    public float speed = 10f;
    public float rotationSpeed = 7f;
    private float pitch = 0f;
    public float pitchSpeed = 7f;
    public float pitchRange = 45f;
    private bool isGrounded;

    public float groundCheckDist = 1.0f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float gravityScale = 3f;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LookAround();
        ApplyGravity();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * moveVertical + right * moveHorizontal;

        controller.Move(movement * speed * Time.deltaTime);
}

void LookAround()
{
    float rotateVertical = Input.GetAxis("Mouse Y");
    float rotateHorizontal = Input.GetAxis("Mouse X");

    Debug.Log("Pitch value: " + Input.GetAxis("Mouse Y"));

    transform.Rotate(Vector3.up * rotateHorizontal * rotationSpeed);

    pitch -= rotateVertical * pitchSpeed;
    pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);

    cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
}

void Jump()
{
    velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity * gravityScale);
}
void ApplyGravity()
{
    isGrounded = controller.isGrounded || IsGrounded();

        if  (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    velocity.y += gravity * gravityScale * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);
}
bool IsGrounded()
{
    return Physics.Raycast(transform.position, Vector3.down, groundCheckDist, groundLayer);
}
}