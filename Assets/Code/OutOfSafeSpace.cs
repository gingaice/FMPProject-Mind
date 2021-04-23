using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfSafeSpace : MonoBehaviour
{
    public Transform _Player;
    public Transform _OutOfHiding;

    [SerializeField]
    public static bool isSafe = false;

    public bool inside = false;

    public Image _interact;
    // Start is called before the first frame update
    void Start()
    {
        isSafe = false;
        _interact.enabled = false;
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
                inside = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            isSafe = true;
            inside = true;
            _interact.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _interact.enabled = false;
    }
}
