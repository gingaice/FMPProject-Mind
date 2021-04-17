using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutPickUp : MonoBehaviour
{
    public Animator DoubleDoor1;
    public Animator DoubleDoor2;

    public string key = "e";

    public float _timer = 0;
    public float _startTimer = 0;
    public float _holdTime = 3;
    public bool held = false;

    public Text pogup;
    // Start is called before the first frame update
    void Start()
    {
        DoubleDoor1.enabled = false;
        DoubleDoor2.enabled = false;

        pogup.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            _startTimer = Time.time;
            _timer = _startTimer;
        }

        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey(key) && held == false)
        {
            _timer += Time.deltaTime;

            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (_timer > (_startTimer + _holdTime))
            {
                pogup.enabled = true;
                held = true;
                ButtonHeld();
            }
        }

        if(held == true)
        {
            DoubleDoor1.enabled = true;
            DoubleDoor2.enabled = true;
        }
        if (Input.GetKeyUp(key))
        {
            pogup.enabled = false;
        }
    }


    void ButtonHeld()
    {

        Debug.Log("held for " + _holdTime + " seconds");
    }

}
