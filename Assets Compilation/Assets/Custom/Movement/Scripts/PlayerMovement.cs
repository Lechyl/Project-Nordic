using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ip;

    public GameObject ep;

    public PlayerStats playerStats;

    public CharacterController controller;
    
    public Transform feetIsOnGround;

    public LayerMask groundMask;

    [SerializeField] public StaminaBar staminaBar;


    Vector3 velocity;

    public bool isGrounded;

    void Start()
    {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is on ground
        isGrounded = Physics.CheckSphere(feetIsOnGround.position, playerStats.groundDistance, groundMask);

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
            if (playerStats.CurrentStamina > 1)
            {
                controller.Move(move * playerStats.SprintSpeed * Time.deltaTime);

                if (Input.GetKey(KeyCode.W))
                {
                    playerStats.CurrentStamina = playerStats.CurrentStamina - 0.3f;
                    staminaBar.SetSize();

                }
            }
            else
            {
                //Walking
                controller.Move(move * playerStats.WalkSpeed * Time.deltaTime);
            }
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

        

        Menu();
        
    }

    //InventoryToggle ON/OFF
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
             ip = Inventory.instance.InventoryPanel;
             ep = Inventory.instance.EquipmentUI;
                
            if (!ip.activeSelf || !ep.activeSelf)
            {
                ip.SetActive(true);
                ep.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                ip.SetActive(false);
                ep.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }
}


