using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMovement : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera cameraa;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }
    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //move in the direction we are aiming
        var moevementVector = MoveTowardTarget(targetVector);

        //rotate in the way were going
        RotateTowardMovementVector(movementVector);

    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, cameraa.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
