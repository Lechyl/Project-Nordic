using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerStats playerStats;

    public CharacterController controller;
    
    public Transform groundCheck;

    public LayerMask groundMask;


    Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, playerStats.groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //Sprinting
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            controller.Move(move * playerStats.SprintSpeed * Time.deltaTime);
        }
        else
        {
        //Walking
            controller.Move(move * playerStats.WalkSpeed * Time.deltaTime);
        }

        //Jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerStats.jumpHeight * -1f * playerStats.gravity);
        }

       /* //Crouching/Sneaking
        if(Input.GetKey(KeyCode.LeftControl))
        {
            controller.Height = 5.0f;
        }
        */

        velocity.y += playerStats.gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
    }
}


