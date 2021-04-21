using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp2 : MonoBehaviour
{
    public Transform card;
    public bool cardMovement;
    public Transform cardMap;
    public bool DoorCan = false;

    //public Transform _cardPlacement;
    public float cardPlacement;
    public float one = 15f;

    public Transform SpawnPoint1;
    public bool cardfreeze1 = false;
    public Transform SpawnPoint2;
    public bool cardfreeze2 = false;
    public Transform SpawnPoint3;
    public bool cardfreeze3 = false;
    public Transform SpawnPoint4;
    public bool cardfreeze4 = false;
    public Transform SpawnPoint5;
    public bool cardfreeze5 = false;
    public Transform SpawnPoint6;
    public bool cardfreeze6 = false;
    public Transform SpawnPoint7;
    public bool cardfreeze7 = false;
    public Transform SpawnPoint8;
    public bool cardfreeze8 = false;

    public bool _inColl = false;

    public Animator door1anim;
    public Animator door2anim;

    public Text Carrying;
    public Text CardSpawned;

    //[SerializeField]
    //List<SpawnPoints> _Spawnpoints;

    //public GameObject[] _Spawnpoints;

    //public int _currentPlacementSpawnIndex;

    public string key = "e";

    public float _timer = 0;
    public float _startTimer = 0;
    public float _holdTime = 3;
    public bool held = false;

    //private int rand;
    //private spawnPointData templates;

    // Start is called before the first frame update
    void Start()
    {
        door1anim.enabled = false;
        door2anim.enabled = false;

        Carrying.enabled = false;
        //templates = GameObject.FindGameObjectWithTag("CardSpawns").GetComponent<spawnPointData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inColl == true)
        {
            // Starts the timer from when the key is pressed
            if (Input.GetKeyDown(key))
            {
                _startTimer = Time.time;
                _timer = _startTimer;
            }

            // Adds time onto the timer so long as the key is pressed
            if (Input.GetKey(key) && held == false)
            {
                _timer += Time.deltaTime;

                // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
                if (_timer > (_startTimer + _holdTime))
                {
                    Carrying.enabled = true;
                    held = true;
                    ButtonHeld();
                    card.position = cardMap.position;
                    DoorCan = true;
                }
            }
        }
        if (Input.GetKeyUp(key))
        {
            Carrying.enabled = false;
        }

        if (Gate2.GateCheck == true)
        {
            cardMovement = true;
        }

        if (cardMovement == true)
        {
            Spawn();
            //cardPlacement = Random.Range(0, 10);
        }
        //Vector3 targetVector = _Spawnpoints[_currentPlacementSpawnIndex].transform.position;
        cardPlacement += Time.deltaTime * one;

        if (cardPlacement >= 15f)
        {
            cardPlacement = 0;
        }

        if (cardfreeze1 == true)
        {
            cardPlacement = 14;
        }
        else if (cardfreeze2 == true)
        {
            cardPlacement = 13;
        }
        else if (cardfreeze3 == true)
        {
            cardPlacement = 11;
        }
        else if (cardfreeze4 == true)
        {
            cardPlacement = 9;
        }
        else if (cardfreeze5 == true)
        {
            cardPlacement = 7;
        }
        else if (cardfreeze6 == true)
        {
            cardPlacement = 5;
        }
        else if (cardfreeze7 == true)
        {
            cardPlacement = 3;
        }
        else if (cardfreeze8 == true)
        {
            cardPlacement = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cards"))
        {
            _inColl = true;
            //DoorCan = true;
        }

        if (other.CompareTag("Gate"))
        {
            if (DoorCan == true)
            {
                if (held == true)
                {
                    door1anim.enabled = true;
                    door2anim.enabled = true;
                }

            }
        }
        //_inColl = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cards"))
        {
            _inColl = false;
        }
        /**
        if (other.CompareTag("Gate"))
        {
            if(DoorCan == true)
            {
                door1anim.enabled = true;
                door2anim.enabled = true;
            }
        }
        **/
    }

    void ButtonHeld()
    {
        card.position = cardMap.position;
        Debug.Log("held for " + _holdTime + " seconds");
    }


    public bool Spawn()
    {
        Debug.Log("number is" + cardPlacement);

        if (cardPlacement >= 14)
        {
            card.position = SpawnPoint1.position;
            cardfreeze1 = true;
            return true;
        }
        else if (cardPlacement >= 12)
        {
            card.position = SpawnPoint2.position;
            cardfreeze2 = true;
            return true;
        }
        else if (cardPlacement >= 10)
        {
            card.position = SpawnPoint3.position;
            cardfreeze3 = true;
            return true;
        }
        else if(cardPlacement >= 8)
        {
            card.position = SpawnPoint4.position;
            cardfreeze4 = true;
            return true;
        }
        else if (cardPlacement >= 6)
        {
            card.position = SpawnPoint5.position;
            cardfreeze5 = true;
            return true;
        }
        else if (cardPlacement >= 4)
        {
            card.position = SpawnPoint6.position;
            cardfreeze6 = true;
            return true;
        }
        else if (cardPlacement >= 2)
        {
            card.position = SpawnPoint7.position;
            cardfreeze7 = true;
            return true;
        }
        else if (cardPlacement >= 0)
        {
            card.position = SpawnPoint8.position;
            cardfreeze8 = true;
            return true;
        }
        return false;
    }
}