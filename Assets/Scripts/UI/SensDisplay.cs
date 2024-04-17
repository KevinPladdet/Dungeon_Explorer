using UnityEngine;
using TMPro;

public class SensDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text sensText;
    [SerializeField] private GameObject canvas;

    void Update()
    {
        sensText.text = canvas.GetComponent<OptionsMenu>().sensValueForDisplay.ToString("0");
    }
}
