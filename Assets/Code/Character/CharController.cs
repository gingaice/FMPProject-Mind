using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;



    void Start()
    {
        //the camera is facing the way that isometric moves so that the character doesnt move on the z path
        forward = Camera.main.transform.forward;
        //for claratiy purposes so that y doesnt change
        forward.y = 0;
        //keeps the vectors direction
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
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
