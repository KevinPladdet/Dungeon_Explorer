using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensController : MonoBehaviour
{
    [SerializeField] private Slider sensSlider;
    [SerializeField] private float defaultSens = 300;

    private void Start()
    {
        float savedSliderValue = PlayerPrefs.GetFloat("sensSliderValue", defaultSens);
        sensSlider.value = savedSliderValue;

        GetComponent<OptionsMenu>().sensValueForDisplay = savedSliderValue;
    }

    public void ChangeSliderSens(float value)
    {
        PlayerPrefs.SetFloat("sensSliderValue", value);
        PlayerPrefs.Save();
    }
}
