using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityStuff : MonoBehaviour
{
    public float damageInsanity = 50;
    public float Mhealth = 500;
    public bool inSight;

    public static bool healthReset;

    //time for timers and health
    public float regenTime;
    public bool regenTrue;

    public Canvas menu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FOVDetection.lockOn1 == true)
        {
            Mhealth -= Time.deltaTime * damageInsanity;
            inSight = true;
        }
        else
        {
            inSight = false;
        }

        if(inSight == true)
        {
            regenTime = 0;
            regenTrue = false;
        }
        else
        {
            regenTrue = true;
        }

        if(regenTrue == true)
        {
            regenTime += Time.deltaTime * damageInsanity;
        }

        if(regenTime >= 500)
        {
            Mhealth += Time.deltaTime * damageInsanity;
        }

        if(Mhealth >= 500)
        {
            Mhealth = 500;
        }

        if (Mhealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Player Died");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.enabled = true;
            Mhealth = 500;
        }

        if (healthReset == true)
        {
            Mhealth = 500;
        }
    }
}
