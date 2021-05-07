using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class etointer : MonoBehaviour
{
    public Image inter;
    // Start is called before the first frame update
    void Start()
    {
        inter.enabled = false;
    }
    void Update()
    {
        if(TutPickUp.Locked == true)
        {
            inter.enabled = false;
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        inter.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inter.enabled = false;
    }
}
