using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3.5f;

    public float _timer = 0f;
    public float _holdTime = 15f;

    float increaser = 1;

    Vector3 forward, right;

    public float _sprintTime = 15f;
    public bool _canSprint = true;
    private bool _speedDecrease = false;

    public Slider _stamBar;

    void Start()
    {


        //the camera is facing the way that isometric moves so that the character doesnt move on the z path
        forward = Camera.main.transform.forward;
        //for claratiy purposes so that y doesnt change
        forward.y = 0;
        //keeps the vectors direction
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        _stamBar.minValue = _timer;
        _stamBar.maxValue = _holdTime;
        _stamBar.value = 15;
        _stamBar.wholeNumbers = true;
        _stamBar.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (_sprintTime >= 15)
        {
            _sprintTime = 15f;
        }

        if(_sprintTime >= 5f)
        {
            _canSprint = true;
        }

        if (Input.anyKey)
        {

            Move();
        }

        if(_canSprint == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (_sprintTime >= 0)
                {
                    _stamBar.gameObject.SetActive(true);
                    _stamBar.value += Time.deltaTime;
                    moveSpeed = 5.5f;
                    _speedDecrease = true;
                    //_sprintTime -= Time.deltaTime * moveSpeed;
                }
            }
        }

        if (_speedDecrease == true)
        {
            _sprintTime -= Time.deltaTime * moveSpeed;
        }

        if(_speedDecrease == false)
        {
            _sprintTime += Time.deltaTime * increaser;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _stamBar.gameObject.SetActive(false);
            moveSpeed = 3.5f;
            _speedDecrease = false;
        }

        if(_sprintTime <= 1)
        {
            _stamBar.gameObject.SetActive(false);
            moveSpeed = 3.5f;
            _speedDecrease = false;
            _canSprint = false;
        }
    }

    private void Move()
    {
        if(OutOfSafeSpace.isSafe == false)
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
            Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

            //this makes rotation happen so that its on isometric instead of normal
            transform.forward = heading;
            //these two make movement happen
            transform.position += rightMovement;
            transform.position += upMovement;
        }

    }

}
