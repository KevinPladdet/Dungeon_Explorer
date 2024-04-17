using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTorch : MonoBehaviour, ILightable
{

    private GameObject torchStick;
    private GameObject torches;
    private VolumeManager AM;

    private void Start()
    {
        AM = VolumeManager.Instance;
        torchStick = GameObject.Find("TorchStick");
        torches = GameObject.Find("Torches");
    }

    bool onlyOnce = false;

    public void LightTorch()
    {
        if (GameObject.FindGameObjectsWithTag("TorchStickTag").Length == 1)
        { 
            // Can't light any torches if torch stick isn't picked up
        }
        else if (!onlyOnce)
        {

            torches.GetComponent<TorchCounter>().activateDrop();

            AM.GetComponent<VolumeManager>().lightFireAudio();

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            gameObject.tag = "Untagged";

            if (GameObject.FindGameObjectsWithTag("TorchTag").Length == 0)
            {
                torchStick.SetActive(false);
            }

            onlyOnce = true;
        }
    }
}
