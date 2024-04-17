using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpSword : MonoBehaviour, IPickupSword
{

    private GameObject player;
    private VolumeManager AM;
    private bool onlyOnce = false;

    [SerializeField] private TextMeshProUGUI objectiveText;

    private void Start()
    {
        AM = VolumeManager.Instance;
        player = GameObject.Find("Main Camera");
    }

    public void PickUpSwordObject()
    {
        if (!onlyOnce)
        {

            gameObject.GetComponent<Animator>().enabled = false;

            AM.GetComponent<VolumeManager>().equipSwordAudio();

            // Makes the sword a child of the player
            gameObject.transform.parent = player.transform;

            // Rotates the sword back to normal
            Quaternion swordRotation = Quaternion.Euler(0.9f, 100f, 2.9f);
            gameObject.transform.localRotation = swordRotation;

            gameObject.transform.localPosition = new Vector3(0.494f, -0.44f, 0.725f);

            gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

            // Locks rotation / position from moving
            //gameObject.transform.localRotation = Quaternion.identity;

            gameObject.GetComponentInChildren<Light>().range = 2f;

            this.GetComponent<MeshCollider>().enabled = false;

            objectiveText.text = "- Defeat the skeletons";

            gameObject.tag = "Untagged";

            this.GetComponent<SwordScript>().hasSword = true;

            onlyOnce = true;
        }
    }
}
