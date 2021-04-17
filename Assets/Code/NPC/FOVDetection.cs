using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVDetection : MonoBehaviour
{
    public Transform player;

    public float maxAngle;
    public float maxRadius;

    private bool isInFOV = false;

    //the lock on stuff
    [SerializeField]
    public static bool lockOn1 = false;

    [SerializeField]
    public static bool lockOn2 = false;

    //public int chasers = 300;

    public bool checker = false;

    private void OnDrawGizmos()
    {
        //this is to get how far the ai can see
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        //this is for the angle that the AI will be able to see from                                                                go to 4:20 for explenation 
        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        //this needs two draw rays as its for both lines of the fov
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFOV)
            //to draw a line between the ai and the player----- the red bit means to say if the player is in and green if out
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);

    }

    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        // this checks every object in the radius of the Ai
        Collider[] overlaps = new Collider[50];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        //uses raycasting to check if the player is behind an object or not
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                            {
                                Debug.Log("player hit");
                                return true;
                            }
                            //Debug.Log("player hit");
                                //return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        isInFOV = inFOV(transform, player, maxAngle, maxRadius);

        if (isInFOV == true)
        {
            lockOn1 = true;
            lockOn2 = true;

            checker = true;
        }
        else
        {
            lockOn1 = false;
            lockOn2 = false;

            checker = false;
        }
        /**
        if (isInFOV == false)
        {
            lockOn = false;
            checker = false;
        }
        **/
    }
}