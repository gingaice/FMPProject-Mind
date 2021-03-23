using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gate.GateCheck = true)
        {
            CardMovement = true;
        }

        if(CardMovement = true)
        {
            card.position = 
        }
    }
    
    void OnTriggerEnter(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.name == "player") ;
            {
                card.position = cardMap.position;
                Safe = true;
            }
        }
    }
}
