using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfSafeSpace : MonoBehaviour
{
    public Transform _Player;
    public Transform _OutOfHiding;

    [SerializeField]
    public static bool isSafe = false;

    public bool inside = false;

    // Start is called before the first frame update
    void Start()
    {
        isSafe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _Player.position = _OutOfHiding.position;
                isSafe = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            isSafe = true;
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            inside = false;
            isSafe = false;
        }
    }
}
