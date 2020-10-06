using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;

    public GameObject PlayButton;
    public GameObject PlayMenu;

    public GameObject SettingsButton;
    public GameObject SettingsMenu;

    public GameObject GraphicsMenu;
    public GameObject AudioMenu;

    public GameObject CreditsButton;
    public GameObject CreditsMenu;

    public GameObject ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    ////////// PLAY ////////////
    public void Playmenu()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }


    ////////// SETTINGS ////////////
    public void Settingsmenu()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void Graphicsmenu()
    {
        SettingsMenu.SetActive(false);
        GraphicsMenu.SetActive(true);
    }

    public void Audiomenu()
    {
        SettingsMenu.SetActive(false);
        AudioMenu.SetActive(true);
    }

    public void BackToSettings()
    {
        SettingsMenu.SetActive(true);
        GraphicsMenu.SetActive(false);
        AudioMenu.SetActive(false);
    }


    ////////// CREDITS ////////////
    public void Creditsmenu()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        PlayMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        AudioMenu.SetActive(false);
        GraphicsMenu.SetActive(false);
    }
}