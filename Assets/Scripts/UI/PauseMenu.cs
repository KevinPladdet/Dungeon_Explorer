using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject MainMenu;

    [SerializeField] private GameObject BackButton;
    [SerializeField] private GameObject ResumeButton;
    [SerializeField] private GameObject MainMenuButton;

    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject objectives;

    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject bgCamera;
    [SerializeField] private GameObject optionsBGCamera;

    [SerializeField] private GameObject onHoverText;

    private bool isPaused = false;

    public bool canActivate = false;

    public void OnPause(InputAction.CallbackContext context)
    {
        if(canActivate)
        {
            if (isPaused)
            {
                BackButton.SetActive(true);
                ResumeButton.SetActive(false);
                MainMenuButton.SetActive(false);
                OptionsMenu.SetActive(false);
                healthBar.SetActive(true);
                objectives.SetActive(true);
                playerCamera.SetActive(true);
                optionsBGCamera.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                isPaused = false;

            }
            else
            {
                OptionsMenu.SetActive(true);
                BackButton.SetActive(false);
                ResumeButton.SetActive(true);
                MainMenuButton.SetActive(true);
                healthBar.SetActive(false);
                objectives.SetActive(false);
                playerCamera.SetActive(false);
                optionsBGCamera.SetActive(true);
                onHoverText.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }

    public void ResumeGame()
    {
        BackButton.SetActive(true);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);
        OptionsMenu.SetActive(false);
        healthBar.SetActive(true);
        objectives.SetActive(true);
        playerCamera.SetActive(true);
        optionsBGCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        BackButton.SetActive(true);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
        healthBar.SetActive(false);
        objectives.SetActive(false);
        playerCamera.SetActive(false);
        bgCamera.SetActive(true);
        optionsBGCamera.SetActive(false);
        onHoverText.SetActive(false);
        isPaused = false;
        canActivate = false;
}
}
