using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractSlider : MonoBehaviour
{
    public Slider _sliderInstance;
    // Start is called before the first frame update
    void Start()
    {
        _sliderInstance.minValue = 0;
        _sliderInstance.maxValue = 100;
        _sliderInstance.wholeNumbers = true;
        _sliderInstance.value = 0;
    }

    public void OnValueChanged(float value)
    {
        Debug.Log("New Value" + value);
    }

    void Update()
    {

    }
}
