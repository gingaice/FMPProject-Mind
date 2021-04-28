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

    // Update is called once per frame
    void Update()
    {
        
    }
}
