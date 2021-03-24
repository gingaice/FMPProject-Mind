using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public static bool GateCheck = false;
    public bool Gaters = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gaters == true)
        {
            GateCheck = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.name == "player")
            {
                Gaters = true;
            }
        }
    }
}
