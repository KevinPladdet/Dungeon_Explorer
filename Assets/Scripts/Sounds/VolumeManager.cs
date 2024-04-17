using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{

    [SerializeField] private AudioSource lightFireSFX;
    [SerializeField] private AudioSource pickUpSFX;
    [SerializeField] private AudioSource equipSwordSFX;
    [SerializeField] private AudioSource openDoorSFX;
    [SerializeField] private AudioSource closeDoorSFX;
    [SerializeField] private AudioSource swordFallSFX;
    [SerializeField] private AudioSource swordSwingSFX;
    [SerializeField] private AudioSource boneHitSFX;
    [SerializeField] private AudioSource playerDeathSFX;

    [SerializeField] private AudioSource playerHurtSFX;
    [SerializeField] private AudioSource playerHurtTwoSFX;
    [SerializeField] private AudioSource playerHurtThreeSFX;

    [SerializeField] private AudioSource winSFX;

    public AudioSource musicClip;

    private int randomNumber;

    private static VolumeManager instance;

    public static VolumeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<VolumeManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<VolumeManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void musicAudio()
    {
        musicClip.volume = 1f;
    }

    // Every time a torch is lit
    public void lightFireAudio()
    {
        lightFireSFX.Play();
    }

    // When the torch stick gets picked up
    public void pickUpAudio()
    {
        pickUpSFX.Play();
    }

    // When the sword gets picked up
    public void equipSwordAudio()
    {
        equipSwordSFX.Play();
    }

    // When the door opens
    public void openDoorAudio()
    {
        openDoorSFX.Play();
    }

    // When the door closes
    public void closeDoorAudio()
    {
        closeDoorSFX.Play();
    }

    // When the sword falls and hits the throne
    public void swordFallAudio()
    {
        swordFallSFX.Play();
    }

    // When the sword swings
    public void swordSwingAudio()
    {
        swordSwingSFX.Play();
    }

    // When the enemy gets hit
    public void boneHitAudio()
    {
        boneHitSFX.Play();
    }

    // When the player dies
    public void playerDeathAudio()
    {
        playerDeathSFX.Play();
    }

    // When the player wins
    public void playerWinAudio()
    {
        winSFX.Play();
    }

    // When the player gets bonked by a skeleton
    public void playerHurtAudio()
    {
        randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                playerHurtSFX.Play();
                break;
            case 2:
                playerHurtTwoSFX.Play();
                break;
            case 3:
                playerHurtThreeSFX.Play();
                break;
            default:
                Debug.Log("This option should never happen, if this shows up in console than check the problem out.");
                break;
        }
    }
}
