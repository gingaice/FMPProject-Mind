using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutSpawnIn : MonoBehaviour
{
    
    public Transform _key;

    public Transform _Dummy1;

    public Transform _Point1;
    public float _ishere1 = 0;
    public Transform _point2;
    public float _ishere2 = 0;

    public bool _inColl = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inColl == true)
        {
            // Starts the timer from when the key is pressed
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
                    Carrying.enabled = true;
                    held = true;
                    ButtonHeld();
                    card.position = cardMap.position;
                    DoorCan = true;
                }
            }
        }
    }

    void onTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            _inColl = true;
        }
        
    }
    
}
