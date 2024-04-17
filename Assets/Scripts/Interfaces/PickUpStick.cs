using UnityEngine;
using TMPro;

public class PickUpStick : MonoBehaviour, IPickupable
{

    [SerializeField] private Camera player;
    private VolumeManager AM;
    bool onlyOnce = false;

    private GameObject holdingCamera;

    [SerializeField] private TextMeshProUGUI objectiveText;

    private void Start()
    {
        AM = VolumeManager.Instance;
        holdingCamera = GameObject.Find("HoldingCamera");
    }

    public void PickUpTorchStick()
    {
        if (!onlyOnce)
        {

            AM.GetComponent<VolumeManager>().pickUpAudio();

            // Makes the torch stick a child of the player
            // SWITCH THESE 2 TO MAKE THE HOLDING CAMERA RENDER TEXTURE WORK
            // (Note for future: I have tried everything and I have no clue what to do.
            // The FX_standard material needs to be transparent, but I can't change the values.
            // I have found the cause of the bug, but I can't fix it.
            gameObject.transform.parent = player.transform;
            //gameObject.transform.parent = holdingCamera.transform;

            // Rotates the torch stick back to normal
            Quaternion stickRotation = Quaternion.Euler(5.9f, 131f, -22f);
            gameObject.transform.localRotation = stickRotation;

            gameObject.transform.localPosition = new Vector3(0.76f, -1.19f, 1.16f);

            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

            // Locks rotation / position from moving
            //gameObject.transform.localRotation = Quaternion.identity;

            objectiveText.text = "- Light the torches";

            gameObject.tag = "Untagged";

            onlyOnce = true;
        }
    }
}
