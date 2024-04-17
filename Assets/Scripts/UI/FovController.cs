using UnityEngine;
using UnityEngine.UI;

public class FovController : MonoBehaviour
{
    [SerializeField] private Slider fovSlider;
    [SerializeField] private float defaultFOV = 60;

    private void Start()
    {
        float savedSliderValue = PlayerPrefs.GetFloat("fovSliderValue", defaultFOV);
        fovSlider.value = savedSliderValue;

        GetComponent<OptionsMenu>().fovValueForDisplay = savedSliderValue;
    }

    public void ChangeSliderFov(float value)
    {
        PlayerPrefs.SetFloat("fovSliderValue", value);
        PlayerPrefs.Save();
    }
}
