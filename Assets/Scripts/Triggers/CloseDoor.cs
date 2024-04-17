using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{

    private GameObject rightDoor;
    private GameObject leftDoor;

    private VolumeManager AM;

    private bool onlyOnce = false;

    void Start()
    {
        AM = VolumeManager.Instance;
        rightDoor = GameObject.Find("RightDoorWood");
        leftDoor = GameObject.Find("LeftDoorWood");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !onlyOnce)
        {
            StartCoroutine(startSFX());
            onlyOnce = true;
        }  
    }

    IEnumerator startSFX()
    {
        rightDoor.GetComponent<Animator>().SetFloat("direction", -0.15f);
        leftDoor.GetComponent<Animator>().SetFloat("direction", -0.15f);
        yield return new WaitForSeconds(1f);
        AM.GetComponent<VolumeManager>().closeDoorAudio();
    }
}
