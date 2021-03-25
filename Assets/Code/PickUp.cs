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
            if (Input.GetKeyDown(KeyCode.E))
            {
                card.position = cardMap.position;
                DoorCan = true;
            }

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
                door1anim.enabled = true;
                door2anim.enabled = true;
            }
        }
        //_inColl = true;

        /**
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.name == "Card")
            {
                card.position = cardMap.position;
                DoorCan = true;
            }
        }
        **/
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

    private void Spawn()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= cardPlacement1)
        {
            card.position = _cardPlacement1.position;
        }
        //Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
    }
}
