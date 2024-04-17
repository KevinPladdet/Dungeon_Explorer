using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorchCounter : MonoBehaviour
{

    private int litCounter;
    private GameObject sword;
    private Animator swordAnim;
    private VolumeManager AM;

    [SerializeField] private TextMeshProUGUI objectiveText;

    void Start()
    {
        AM = VolumeManager.Instance;
        sword = GameObject.Find("Sword");
        swordAnim = sword.GetComponent<Animator>();

        sword.SetActive(false);
    }

    public void activateDrop()
    {
        litCounter++;
        if (litCounter == 8)
        {
            sword.SetActive(true);
            swordAnim.enabled = true;
            swordAnim.speed = 0.7f;
            StartCoroutine(waitForFall());
        }
    }

    IEnumerator waitForFall()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        AM.GetComponent<VolumeManager>().swordFallAudio();
        objectiveText.text = "- Investigate the sword";
    }
}
