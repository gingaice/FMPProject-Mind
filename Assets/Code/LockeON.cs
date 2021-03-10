using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class LockeON : FOVDetection
    {
        public int chaser = 3;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (lockOn == true)
            {
                chaser--;

                if (chaser <= 0)
                {
                    lockOn = false;
                }
            }
        }
    }
}
/**
public class LockeON : MonoBehaviour
{
    public int chaser = 3;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lockOn = true)
        {
            chaser--;

            if (chaser <= 0)
            {

            }
        }
    }
}
**/