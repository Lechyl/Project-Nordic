using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerInventory;

    public GameObject equiptmentUI;

    public GameObject tooltipUI;

    public GameObject craftPanel;

    public GameObject trashcan;

    public PlayerStats playerStats;

    public CharacterController controller;

    public Transform feetIsOnGround;

    public LayerMask groundMask;

    public AudioSource footsteps;

    [SerializeField] public StaminaBar staminaBar;


    Vector3 velocity;

    public bool isGrounded;

    private bool InventoryOpen = false;

    void Start()
    {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        footsteps = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is on ground
        isGrounded = Physics.CheckSphere(feetIsOnGround.position, playerStats.groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            if (playerStats.CurrentStamina > 1)
            {

                if (Input.GetKey(KeyCode.W))
                {
                    controller.Move(move * playerStats.SprintSpeed * Time.deltaTime);
                    playerStats.CurrentStamina = playerStats.CurrentStamina - 0.3f;
                    staminaBar.SetSize();

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
        }
        else
        {
            //Walking
            controller.Move(move * playerStats.WalkSpeed * Time.deltaTime);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
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


        //SFX
        if (move.x != 0 && !footsteps.isPlaying || move.z != 0 && !footsteps.isPlaying)
        {
            // AudioSource.PlayClipAtPoint(Footsteps, transform.position);
            footsteps.Play();
        }


        Menu();

    }

    //InventoryToggle ON/OFF
    public void Menu()
    {

        if (Cursor.lockState == CursorLockMode.Locked || InventoryOpen == true)
        {


            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //playerInventory = Inventory.instance.InventoryPanel;
                //equiptmentUI = Inventory.instance.equipmentUI;

                if (!playerInventory.activeSelf && !equiptmentUI.activeSelf)
                {
                    playerInventory.SetActive(true);
                    equiptmentUI.SetActive(true);
                    trashcan.SetActive(true);

                    InventoryOpen = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                }
                else if (playerInventory.activeSelf && equiptmentUI.activeSelf)
                {
                    tooltipUI.SetActive(false);

                    playerInventory.SetActive(false);
                    equiptmentUI.SetActive(false);
                    trashcan.SetActive(false);
                    InventoryOpen = false;

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!craftPanel.activeSelf && !playerInventory.activeSelf)
                {
                    craftPanel.SetActive(true);
                    playerInventory.SetActive(true);
                    InventoryOpen = true;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                }
                else if (craftPanel.activeSelf && playerInventory.activeSelf)
                {
                    craftPanel.transform.Find("Craft1").GetComponent<CraftItemSlot>().ClearCrafting();
                    craftPanel.SetActive(false);
                    playerInventory.SetActive(false);
                    InventoryOpen = false;

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1;
                }
            }
        }
    }
}


