using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject objectives;

    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject bgCamera;

    [SerializeField] private GameObject onHoverText;



    private VolumeManager AM;

    private void Start()
    {
        AM = VolumeManager.Instance;
    }

    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        healthBar.SetActive(true);
        objectives.SetActive(true);
        playerCamera.SetActive(true);
        bgCamera.SetActive(false);
        onHoverText.SetActive(true);
        Time.timeScale = 1f;
        pauseMenu.canActivate = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
