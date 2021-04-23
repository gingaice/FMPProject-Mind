using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutTeach : MonoBehaviour
{
    public bool freeze;

    public float _timer = 0;
    public float _ScreenTime = 0.075f;

    public bool _TimeGoUp;

    public Image _findthekey;
    // Start is called before the first frame update
    void Start()
    {
        _findthekey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze == true)
        {
            Time.timeScale = 0.1f;
            _findthekey.enabled = true;
            _TimeGoUp = true;
        }

        if(_TimeGoUp == true)
        {
            _timer += Time.deltaTime;
        }

        //do it so after a bit it will destroy the trigger that you are stood on
        if(_timer >= _ScreenTime)
        {
            Destroy (this.gameObject);
            _timer = 0;
            _TimeGoUp = false;
            _findthekey.enabled = false;
            Time.timeScale = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            freeze = true;
        }
    }
}
