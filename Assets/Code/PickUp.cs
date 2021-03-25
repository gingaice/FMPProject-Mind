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

    public bool _inZone = false;


    public Animator door1anim;
    public Animator door2anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_inZone == true)
        {
            card.position = cardMap.position;
            DoorCan = true;
        }

        if(DoorCan == true)
        {
            door1anim.enabled = true;
            door2anim.enabled = true;
        }

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
        _inZone = true;

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

    private void Spawn()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= cardPlacement1)
        {
            card.position = _cardPlacement1.position;
        }
        //Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
    }
}
