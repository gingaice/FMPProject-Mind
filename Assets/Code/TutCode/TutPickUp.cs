using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPickUp : MonoBehaviour
{
    public Animator DoubleDoor1;
    public Animator DoubleDoor2;
    // Start is called before the first frame update
    void Start()
    {
        DoubleDoor1.enabled = false;
        DoubleDoor2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            DoubleDoor1.enabled = true;
            DoubleDoor2.enabled = true;
        }
    }
}
