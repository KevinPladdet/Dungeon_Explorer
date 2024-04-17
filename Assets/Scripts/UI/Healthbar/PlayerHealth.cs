using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int currentHealth;

	int amountOfHealing = 3;

	[SerializeField] private Healthbar healthBar;
	[SerializeField] private GameObject gameOverScreen;
	[SerializeField] private GameObject objectives;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject healthBarObject;

	[SerializeField] private GameObject optionsBgCamera;
	[SerializeField] private GameObject playerCamera;

	private VolumeManager AM;

	void Start()
	{
		AM = VolumeManager.Instance;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
		// I don't know if I will add healing to the game, but I added it as a prototype which can be used with "O"
		// I know this is the old input system, but since I won't explain the mechanic or expect anyone to use it, I don't really care for now
		// (If I ever will add this mechanic, I will explain it and will use the new input system)
		if ((Input.GetKeyDown(KeyCode.O)) && amountOfHealing >= 1)
		{
			Heal();
		}
	}

	public void TakeDamage(int damage)
	{	
		if (currentHealth == 20)
		{
			// Game Over Screen
			AM.GetComponent<VolumeManager>().musicClip.volume = 0f;
			AM.GetComponent<VolumeManager>().playerDeathAudio();
			objectives.SetActive(false);
			gameOverScreen.SetActive(true);
			mainMenu.SetActive(false);
			healthBarObject.SetActive(false);
			playerCamera.SetActive(false);
			optionsBgCamera.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
		}
		else
        {
			AM.GetComponent<VolumeManager>().playerHurtAudio();
			currentHealth -= damage;
			healthBar.SetHealth(currentHealth);
		}
	}

	public void Heal()
	{
		// Put healing audio here
		Debug.Log("healed");
		currentHealth += 40;
		amountOfHealing--;
		healthBar.SetHealth(currentHealth);
	}
}
