using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public StaminaBar staminaBar;

    public float speed = 5;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool gameRunning;

    Vector3 velocity;
    bool isGrounded;

    public void StopGame() {
        gameRunning = false;
    }

    public void StartGame() {
        gameRunning = true;
    }

    void Start() {
        StartGame();
    }

    void Update()
    {
        // Once the game is over, stop all movement
        if (gameRunning) {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetKey("left shift") && staminaBar.CanSprint())
            {
                staminaBar.isSprinting = true;
                speed = 8;
            }
            else
            {
                if (staminaBar.isSprinting) {
                    staminaBar.ResetRegenTimer();
                }
                staminaBar.isSprinting = false;
                speed = 4;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}