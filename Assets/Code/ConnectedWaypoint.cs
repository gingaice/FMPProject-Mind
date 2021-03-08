using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Coding
{
    public class ConnectedWaypoint : Waypoint
    {
        [SerializeField]
        protected float _connectivityRadius = 50f;

        List<ConnectedWaypoint> _connections;

        public void Start()
        {
            //grab all waypoint objects in scene
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            //create a list of waypoints to refer to later
            _connections = new List<ConnectedWaypoint>();

            //check if they're connected waypoint
            for (int i = 0; i < allWaypoints.Length; i++)
            {
                ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>();

                //i.e we found a waypoint
                if (nextWaypoint != null)
                {
                    //at the end of this with the != this checks to see that the next waypoint isnt the one that its on
                    if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this)
                    {
                        _connections.Add(nextWaypoint);
                    }
                }
            }
        }

        public override void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
        }
        
        public ConnectedWaypoint nextWaypoint(ConnectedWaypoint previousWaypoint)
        {
            if (_connections.Count == 0)
            {
                //no waypoints? return null and console complaints
                Debug.LogError("Insufficient waypoint count :)");
                return null;
            }
            else if (_connections.Count == 1 && _connections.Contains(previousWaypoint))
            {
                //Only one waypoint and its the previous one? just use it
                return previousWaypoint;
            }
            else //otherwise find a random one that isnt prevois one
            {
                ConnectedWaypoint nextWaypoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, _connections.Count);
                    nextWaypoint = _connections[nextIndex];

                } while (nextWaypoint == previousWaypoint);

                return nextWaypoint;
            }

        }
    }
}
