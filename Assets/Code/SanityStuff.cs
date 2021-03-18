using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityStuff : MonoBehaviour
{
    public float damageInsanity = 50;
    public float Mhealth = 1000;
    public bool inSight;

    //time for timers and health
    public float regenTime;
    public bool regenTrue;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FOVDetection.lockOn == true)
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

        if(Mhealth >= 1000)
        {
            Mhealth = 1000;
        }

        if (Mhealth <= 0)
        {

            Application.Quit();
        }
    }
}
