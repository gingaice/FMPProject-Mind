using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpace : MonoBehaviour
{
    public Transform _Player;
    public Transform _HidingSpot;
    public Transform _OutOfHiding;

    [SerializeField]
    public static bool isSafe = false;

    public bool checker = false;
    // Start is called before the first frame update
    void Start()
    {
        isSafe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                _Player.position = _HidingSpot.position;
                isSafe = true;
                checker = true;
            }
            //isSafe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                _Player.position = _OutOfHiding.position;
                isSafe = false;
                checker = false;
            }
        }
    }
}
