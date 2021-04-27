using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    public static bool GateCheck = false;
    public bool Gaters = false;

    public bool _inZone = false;

    public Image press;
    // Start is called before the first frame update
    void Start()
    {
        press.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_inZone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Gaters = true;
            }
        }

        if(Gaters == true)
        {
            GateCheck = true;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        _inZone = true;
        press.enabled = true;
        /**
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.name == "player")
            {
                Gaters = true;
            }
        }
        **/
    }

    
    private void OnTriggerExit(Collider other)
    {
        _inZone = false;
        press.enabled = false;
    }
    
}
