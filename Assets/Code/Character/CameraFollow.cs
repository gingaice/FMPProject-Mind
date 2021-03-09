using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    public Transform target;



    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    [SerializeField]

    private float minX, maxX, minY, maxY;



    private void Awake()

    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void FixedUpdate()

    {

        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.deltaTime);

    }

}