using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;

    Resolution[] resolutions;

    public float fovValueForDisplay;
    public float sensValueForDisplay;

    private void Start()
    {

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetMusic(float musicVolume)
    {
        musicMixer.SetFloat("musicVolume", musicVolume);
    }

    public void SetSensitivity(float sens)
    {
        player.GetComponent<PlayerController>().sensitivity = sens;
        sensValueForDisplay = sens;
    }

    public void SetFOV(float fov)
    {
        mainCamera.GetComponent<Camera>().fieldOfView = fov;
        fovValueForDisplay = fov;
    }
}
