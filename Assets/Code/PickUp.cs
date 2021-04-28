using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Transform card;
    public bool cardMovement;
    public Transform cardMap;
    public bool DoorCan = false;

    //public Transform _cardPlacement;
    public float cardPlacement;
    public float one = 10f;

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

    public bool _inColl = false;

    public Animator door1anim;
    public Animator door2anim;

    public Image Carrying;
    public Image inter;

    public string key = "e";

    public float _timer = 0;
    public float _startTimer = 0;
    public float _holdTime = 1;
    public bool held = false;

    public Slider _sliderInstance;

    // Start is called before the first frame update
    void Start()
    {
        door1anim.enabled = false;
        door2anim.enabled = false;

        Carrying.enabled = false;

        _sliderInstance.minValue = _timer;
        _sliderInstance.maxValue = _holdTime;
        _sliderInstance.value = 0;
        _sliderInstance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_inColl == true)
        {
            // Starts the timer from when the key is pressed
            if (Input.GetKeyDown(key))
            {
                _startTimer = Time.time;
                _timer = _startTimer;
                _sliderInstance.value = 0;
            }

            // Adds time onto the timer so long as the key is pressed
            if (Input.GetKey(key) && held == false)
            {
                _sliderInstance.gameObject.SetActive(true);
                _timer += Time.deltaTime;
                _sliderInstance.value += Time.deltaTime;
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
            _sliderInstance.gameObject.SetActive(false);
        }
        if(held == true)
        {
            inter.enabled = false;
        }
        if (Gate.GateCheck == true)
        {
            cardMovement = true;
        }

        if(cardMovement == true)
        {
            Spawn();
            //cardPlacement = Random.Range(0, 10);
        }
        //Vector3 targetVector = _Spawnpoints[_currentPlacementSpawnIndex].transform.position;
        cardPlacement += Time.deltaTime * one;

        if (cardPlacement >= 10f)
        {
            cardPlacement = 0;
        }

        if (cardfreeze1 == true)
        {
            cardPlacement = 9;
        }
        else if (cardfreeze2 == true)
        {
            cardPlacement = 7;
        }
        else if (cardfreeze3 == true)
        {
            cardPlacement = 5;
        }
        else if (cardfreeze4 == true)
        {
            cardPlacement = 3;
        }
        else if (cardfreeze5 == true)
        {
            cardPlacement = 1;
        }

    }

    public void OnValueChanged(float value)
    {
        Debug.Log("New Value" + value);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cards"))
        {
            _inColl = true;
           
            inter.enabled = true;
            
            //DoorCan = true;
        }

        if (other.CompareTag("Gate"))
        {
            if (DoorCan == true)
            {
                if(held == true)
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
            inter.enabled = false;
            _inColl = false;
        }
    }

    void ButtonHeld()
    {
        card.position = cardMap.position;
        Debug.Log("held for " + _holdTime + " seconds");
    }


    public bool Spawn()
    {
        Debug.Log("number is" + cardPlacement);

        if (cardPlacement >= 8)
        {
            card.position = SpawnPoint1.position;
            cardfreeze1 = true;
            return true;
        }
        else if (cardPlacement >= 6)
        {
            card.position = SpawnPoint2.position;
            cardfreeze2 = true;
            return true;
        }
        else if (cardPlacement >= 4)
        {
            card.position = SpawnPoint3.position;
            cardfreeze3 = true;
            return true;
        }
        else if (cardPlacement >= 2)
        {
            card.position = SpawnPoint4.position;
            cardfreeze4 = true;
            return true;
        }
        else if (cardPlacement >= 0)
        {
            card.position = SpawnPoint5.position;
            cardfreeze5 = true;
            return true;
        }
        return false;
    }
}

/**
private List<GameObject> pollenSpores = new List<GameObject>();
private void Spawn()
{
    // Initialize a pool of spawn locations from the full list
    List<Transform> spawnPool = new List<Transform>(spawnLocations);
    // Spawn 4 spores
    for (int i = 0; i < 4; ++i)
    {
        // Get next random spawn location from pool and then remove it from the list
        Transform spawnLocation = spawnPool[Random.Range(0, spawnPool.Count)];
        spawnPool.Remove(spawnLocation);
        pollenSpores.Add(Instantiate(prefabToSpawn[i], spawnLocation.position, Quaternion.identity));
    }
}
        /**
        if (UnityEngine.Random.Range(0f, 1f) == cardPlacement)
        {
            if(cardPlacement >= 0.9)
            {
                card.position = _cardPlacement.position;
                //_currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
                //_currentPlacementSpawnIndex = (_currentPlacementSpawnIndex + 1) % _Spawnpoints;
            }
        }

        rand = Random.Range(0, templates.randomSpawn.Length);
        Instantiate(templates.randomSpawn[rand], transform.position, Quaternion.identity);
        card.transform.position = spawnPointData[RandomSpawn].position;

                if (test == 1)
        {
            rand = Random.Range(0, templates.randomSpawn.Length);
            Instantiate(templates.randomSpawn[rand], transform.position, Quaternion.identity);
        }

                rand = Random.Range(0, templates.randomSpawn.Length);
        Instantiate(templates.randomSpawn[rand], transform.position, Quaternion.identity);

        card.position = _cardPlacement.position;
        **/
/**
private void Spawn()
{
    Debug.Log("number is" + cardPlacement);

    if (cardPlacement >= 8)
    {
        card.position = SpawnPoint1.position;
    }
    else if (cardPlacement >= 6)
    {
        card.position = SpawnPoint2.position;
    }
    else if (cardPlacement >= 4)
    {
        card.position = SpawnPoint3.position;
    }
    else if (cardPlacement >= 2)
    {
        card.position = SpawnPoint4.position;
    }
    else if (cardPlacement >= 0)
    {
        card.position = SpawnPoint5.position;
    }

}
        if (cardfreeze1 == true)
        {
            cardPlacement = 9;
        }
        else if (cardfreeze1 == true)
        {
            cardPlacement = 7;
        }
        else if (cardfreeze1 == true)
        {
            cardPlacement = 5;
        }
        else if (cardfreeze1 == true)
        {
            cardPlacement = 3;
        }
        else if (cardfreeze1 == true)
        {
            cardPlacement = 1;
        }


        
        if (stopper == false)
        {
            cardPlacement = Random.Range(0, 10);
        }

**/