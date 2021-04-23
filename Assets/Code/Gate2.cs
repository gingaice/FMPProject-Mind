using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2 : MonoBehaviour
{
    [SerializeField]
    public static bool GateCheck = false;

    public bool Gaters = false;

    public bool _inZone = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_inZone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Gaters = true;
            }
        }

        if (Gaters == true)
        {
            GateCheck = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        _inZone = true;

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
    }

}
