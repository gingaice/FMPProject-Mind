using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCameraPlayer3 : MonoBehaviour
{
    //Public variable to store a reference to the player game object
    public GameObject player;
    //The current wall
    private TransparentWall currentTransparentWall;

    private void FixedUpdate()
    {
        //Calculate the Vector direction 
        Vector3 direction = player.transform.position - transform.position;
        //Calculate the length
        float length = Vector3.Distance(player.transform.position, transform.position);
        //Draw the ray in the debug
        Debug.DrawRay(transform.position, direction * length, Color.green);
        //The first object hit reference
        RaycastHit currentHit;
        //Cast the ray and report the firt object hit filtering by "Wall" layer mask
        if (Physics.Raycast(transform.position, direction, out currentHit, length, LayerMask.GetMask("Wall")))
        {
            //Getting the script to change transparency of the hit object
            TransparentWall transparentWall = currentHit.transform.GetComponent<TransparentWall>();
            //If the object is not null
            if (transparentWall)
            {
                //If there is a previous wall hit and it's different from this one
                if (currentTransparentWall && currentTransparentWall.gameObject != transparentWall.gameObject)
                {
                    //Restore its transparency setting it not transparent
                    currentTransparentWall.ChangeTransparency(false);
                }
                //Change the object transparency in transparent.
                transparentWall.ChangeTransparency(true);
                currentTransparentWall = transparentWall;
            }
        }
        else
        {
            //If nothing is hit and there is a previous object hit
            if (currentTransparentWall)
            {
                //Restore its transparency setting it not transparent
                currentTransparentWall.ChangeTransparency(false);
            }
        }
    }
}