using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeSpace : MonoBehaviour
{
    public Transform _Player;
    public Transform _HidingSpot;

    [SerializeField]
    public static bool isSafe = false;

    public bool checker = false;

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
        if(checker == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _Player.position = _HidingSpot.position;
                checker = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            checker = true;
            _interact.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            checker = false;
            _interact.enabled = false;
        }
    }
}
