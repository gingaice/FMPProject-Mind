using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform card;
    public bool cardMovement;
    public Transform cardMap;
    public bool DoorCan = false;

    public Transform _cardPlacement1;
    public float cardPlacement1 = 0.2f;

    public bool _inColl = false;

    public Animator door1anim;
    public Animator door2anim;

    public string key = "e";

    public float _timer = 0;
    public float _startTimer = 0;
    public float _holdTime = 1;
    public bool held = false;

    // Start is called before the first frame update
    void Start()
    {
        door1anim.enabled = false;
        door2anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_inColl == true)
        {
            /**
            _PickupTimer = 0;
            _PickupTimer += Time.deltaTime * _PickupTimerUp;

            if(_PickupTimer >= 10)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    card.position = cardMap.position;
                    DoorCan = true;
                    _PickupTimer = 0;
                }
            }
            **/

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
                    held = true;
                    ButtonHeld();
                    card.position = cardMap.position;
                    DoorCan = true;
                }
            }

            // For single effects. Remove if not needed
            if (Input.GetKeyUp(key))
            {
                held = false;
            }

            /**
            if (Input.GetKeyDown(KeyCode.E))
            {
                _startTimer = Time.time;
                _timer = _startTimer;

                if (_startTimer + _HoldTime >= Time.time)
                {
                    card.position = cardMap.position;
                    DoorCan = true;
                }
            }
            else
            {
                _startTimer = 0;
            }
            **/
            //card.position = cardMap.position;
            //DoorCan = true;
        }

        /**
        if(DoorCan == true)
        {
            door1anim.enabled = true;
            door2anim.enabled = true;
        }
        **/

        if(Gate.GateCheck == true)
        {
            cardMovement = true;
        }

        if(cardMovement == true)
        {
            Spawn();
            //card.position = //random spot
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cards"))
        {
            _inColl = true;
            //DoorCan = true;
        }

        if (other.CompareTag("Gate"))
        {
            if (DoorCan == true)
            {
                if(held = true)
                {
                    door1anim.enabled = true;
                    door2anim.enabled = true;
                }

            }
        }
        //_inColl = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cards"))
        {
            _inColl = false;
        }
        /**
        if (other.CompareTag("Gate"))
        {
            if(DoorCan == true)
            {
                door1anim.enabled = true;
                door2anim.enabled = true;
            }
        }
        **/
    }

    void ButtonHeld()
    {
        Debug.Log("held for " + _holdTime + " seconds");
    }

    private void Spawn()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= cardPlacement1)
        {
            card.position = _cardPlacement1.position;
        }
        //Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
    }
}
