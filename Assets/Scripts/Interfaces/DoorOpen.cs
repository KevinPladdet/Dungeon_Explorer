using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IOpenable
{

    private Animator jewelAnim;

    private GameObject rightDoor;
    private GameObject leftDoor;

    private VolumeManager AM;

    private bool onlyOnce = false;

    void Start()
    {
        AM = VolumeManager.Instance;
        jewelAnim = gameObject.GetComponent<Animator>();
        rightDoor = GameObject.Find("RightDoorWood");
        leftDoor = GameObject.Find("LeftDoorWood");
    }

    public void OpenDoor()
    {
        if (!onlyOnce)
        {
            jewelAnim.enabled = true;
            jewelAnim.speed = 0.5f;

            StartCoroutine(startDoor());

            gameObject.tag = "Untagged";

            onlyOnce = true;
        }
    }

    IEnumerator startDoor()
    {
        yield return new WaitForSeconds(2f);
        AM.GetComponent<VolumeManager>().openDoorAudio();
        rightDoor.GetComponent<Animator>().enabled = true;
        leftDoor.GetComponent<Animator>().enabled = true;
    }
}