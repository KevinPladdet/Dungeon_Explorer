using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FovDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text fovText;
    [SerializeField] private GameObject canvas;

    void Update()
    {
        fovText.text = canvas.GetComponent<OptionsMenu>().fovValueForDisplay.ToString("0");
    }
}
