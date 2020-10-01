using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    public GameObject enemyInventoryUI;
    public GameObject playerInventoryUI;
    public GameObject equipmentUI;
    public GameObject npcPanelUI;
    public GameObject questPanelUI;
    public GameObject questScrollPanelUI;
    public GameObject pickUpUI;
    public GameObject interactUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }
    private void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerInventoryUI.SetActive(false);
        enemyInventoryUI.SetActive(false);
        equipmentUI.SetActive(false);

        npcPanelUI.SetActive(false);
        questPanelUI.SetActive(false);
        questScrollPanelUI.SetActive(false);
        pickUpUI.SetActive(false);
        interactUI.SetActive(false);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Options()
    {

    }

    public void QuitGame()
    {

    }
}
