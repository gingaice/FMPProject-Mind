using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vents : MonoBehaviour
{
    public bool CanTele = false;

    public Transform Player;
    public Transform otherVent;

    public bool stopper;
    public float stopperTime;
    public float speed = 1;

    public Image presse;
    // Start is called before the first frame update
    void Start()
    {
        presse.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanTele == true)
        {
            if(stopper == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Player.position = otherVent.position;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            stopper = true;
        }

        if(stopper == true)
        {
            CanTele = false;
            stopperTime += Time.deltaTime * speed;
        }

        if (stopperTime >= 1)
        {
            stopper = false;
        }
        if (stopper == false)
        {
            stopperTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CanTele = true;
        presse.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        presse.enabled = false;
        CanTele = false;
    }
}
