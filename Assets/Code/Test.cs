using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform Player;
    public Transform SpawnTut;
    // Start is called before the first frame update
    void Start()
    {
        Player.position = SpawnTut.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
