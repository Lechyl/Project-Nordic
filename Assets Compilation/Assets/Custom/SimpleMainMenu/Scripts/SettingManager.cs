using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown TextureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Button applyButton;
    public Button BackButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    public GameObject GraphicsMenu;
    public GameObject SettingsMenu;

    private string path = "";
    void OnEnable()
    {
        path = Application.dataPath;
        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            path += "/../../";
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path += "/../";
        }

        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        TextureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }
    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        Debug.Log("Fullscreen?");
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = TextureQualityDropdown.value;
    }

    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antialiasingDropdown.value);
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText($"{path}/Custom/Savefiles/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        //C:/Users/aznzl/Desktop/Github/Project-Nordic/Assets Compilation/Assets/Custom/Savefiles
        string jsonString = File.ReadAllText($"{path}/Custom/Savefiles/gamesettings.json");

        //        gameSettings = JsonUtility.FromJson<GameSettings>($"{path}/Custom/Savefiles/gamesettings.json");
        gameSettings = JsonUtility.FromJson<GameSettings>(jsonString);

        antialiasingDropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;
        TextureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();

    }

}

