using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutPickUp : MonoBehaviour
{
    public Animator DoubleDoor1;
    public Animator DoubleDoor2;

    public bool canHold;

    public string key = "e";

    public float _timer = 0;
    public float _startTimer = 0;
    public float _holdTime = 1;
    public bool held = false;

    public Image pogup;
    public Image nothingup;
    public Image HoldDown;

    public Slider _sliderInstance;

    public static bool Locked = false;

    // Start is called before the first frame update
    void Start()
    {
        DoubleDoor1.enabled = false;
        DoubleDoor2.enabled = false;

        pogup.enabled = false;
        HoldDown.enabled = false;
        nothingup.enabled = false;

        _sliderInstance.minValue = _timer;
        _sliderInstance.maxValue = _holdTime;
        _sliderInstance.value = 0;
        _sliderInstance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canHold == true)
        {
            if (this.gameObject.name == "Dummy")
            {
                if (Input.GetKeyDown(key))
                {
                    _startTimer = Time.time;
                    _timer = _startTimer;
                    _sliderInstance.value = 0;
                }

                // Adds time onto the timer so long as the key is pressed
                if (Input.GetKey(key) && held == false)
                {
                    _sliderInstance.gameObject.SetActive(true);
                    _timer += Time.deltaTime;
                    _sliderInstance.value += Time.deltaTime;
                    // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
                    if (_timer > (_startTimer + _holdTime))
                    {
                        nothingup.enabled = true;
                    }
                }

                if (Input.GetKeyUp(key))
                {
                    nothingup.enabled = false;
                    _sliderInstance.gameObject.SetActive(false);
                }
            }
            if (this.gameObject.name == "Key")
            {
                if (Input.GetKeyDown(key))
                {
                    _startTimer = Time.time;
                    _timer = _startTimer;
                    _sliderInstance.value = 0;
                }

                // Adds time onto the timer so long as the key is pressed
                if (Input.GetKey(key) && held == false)
                {
                    _sliderInstance.gameObject.SetActive(true);
                    _timer += Time.deltaTime;
                    _sliderInstance.value += Time.deltaTime;
                    // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
                    if (_timer > (_startTimer + _holdTime))
                    {
                        Locked = true;
                        pogup.enabled = true;
                        held = true;
                        ButtonHeld();
                    }
                }

                if (held == true)
                {
                    DoubleDoor1.enabled = true;
                    DoubleDoor2.enabled = true;
                }

                if (Input.GetKeyUp(key))
                {
                    pogup.enabled = false;
                    held = false;
                    _sliderInstance.gameObject.SetActive(false);
                }
            }
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            canHold = true;
            HoldDown.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            canHold = false;
            HoldDown.enabled = false;
        }
    }

    void ButtonHeld()
    {

        Debug.Log("held for " + _holdTime + " seconds");
    }

}
