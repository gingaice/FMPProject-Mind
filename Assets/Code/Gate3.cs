using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate3 : MonoBehaviour
{
    [SerializeField]
    public static bool GateCheck = false;

    public bool Gaters = false;

    public bool _inZone = false;

    public Image press;
    public Image locked;
    // Start is called before the first frame update
    void Start()
    {
        press.enabled = false;
        locked.enabled = false;
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
            press.enabled = false;
            GateCheck = true;
        }

        if (PickUpThird.noLock3 == true)
        {
            locked.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        _inZone = true;
        press.enabled = true;
    }


    private void OnTriggerExit(Collider other)
    {
        press.enabled = false;
        _inZone = false;
    }

}
