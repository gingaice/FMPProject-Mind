using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public transform card;
    public transform cardMovement;
    public transform cardMap;
    public bool DoorCan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gate.GateCheck = true)
        {
            cardMovement = true;
        }

        if(cardMovement = true)
        {
            card.position = //random spot
        }
    }
    
    void OnTriggerEnter(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.name == "player");
            {
                card.position = cardMap.position;
                DoorCan = true;
            }
        }
    }
    
}
