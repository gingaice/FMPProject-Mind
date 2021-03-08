using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Coding
{
    public class NPCconnectedPatrol : MonoBehaviour
    {
        //Dictates whther the agent waits on each node
        [SerializeField]
        bool _patrolWaiting;

        //the total time we wait at each node
        [SerializeField]
        float _totalWaitTime = 3f;

        //the probability of switching direction
        [SerializeField]
        float _switchProbability = 0.2f;

        //private variables for base behaviour
        NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;

        bool _travelling;
        bool _waiting;
        float _waitTimer;
        int _waypointsVisited;

        // Start is called before the first frame update
        public void Start()
        {
            //this is too find the navmesh agent on the object that you put it on
            _navMeshAgent = this.GetComponent<NavMeshAgent>();

            if (_navMeshAgent == null)
            {
                Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
            }
            else
            {
                //this is to find the patrol points that i will be putting into the scene for the ai to go too
                if (_currentWaypoint == null)
                {
                    //set it at random
                    //grab all waypoint objects in scene
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

                    if (allWaypoints.Length > 0)
                    {
                        while (_currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                            ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                            //ie we doung a waypoint
                            if (startingWaypoint != null)
                            {
                                _currentWaypoint = startingWaypoint;
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("failed to find any waypoint for use");
                }
            }

            SetDestination();
        }
        // Update is called once per frame
        public void Update()
        {
            //checking to see if were close to the destination that we want to go too
            if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
            {
                _travelling = false;
                _waypointsVisited++;

                //If were going to wait then wait
                if (_patrolWaiting)
                {
                    _waiting = true;
                    _waitTimer = 0f;
                }
                else
                {
                    SetDestination();
                }
            }

            //instead if were waiting
            if (_waiting)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;

                    SetDestination();
                }
            }
        }

        private void SetDestination()
        {
            if (_waypointsVisited > 0)
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.nextWaypoint(_previousWaypoint);
                _previousWaypoint = _currentWaypoint;
                _currentWaypoint = nextWaypoint;
            }

            Vector3 targetVector = _currentWaypoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }
}
/**
public class NPCconnectedPatrol : MonoBehaviour
{
    //Dictates whther the agent waits on each node
    [SerializeField]
    bool _patrolWaiting;

    //the total time we wait at each node
    [SerializeField]
    float _totalWaitTime = 3f;

    //the probability of switching direction
    [SerializeField]
    float _switchProbability = 0.2f;

    //private variables for base behaviour
    NavMeshAgent _navMeshAgent;
    ConnectedWaypoint _currentWaypoint;
    ConnectedWaypoint _previousWaypoint;

    bool _travelling;
    bool _waiting;
    float _waitTimer;
    int _waypointsVisited;

    // Start is called before the first frame update
    public void Start()
    {
        //this is too find the navmesh agent on the object that you put it on
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            //this is to find the patrol points that i will be putting into the scene for the ai to go too
            if (_currentWaypoint == null)
            {
                //set it at random
                //grab all waypoint objects in scene
                GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

                if (allWaypoints.Length > 0)
                {
                    while (_currentWaypoint == null)
                    {
                        int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                        ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                        //ie we doung a waypoint
                        if (startingWaypoint != null)
                        {
                            _currentWaypoint = _startingWaypoint;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("failed to find any waypoint for use");
            }
        }

        SetDestination();
    }
    // Update is called once per frame
    public void Update()
    {
        //checking to see if were close to the destination that we want to go too
        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;
            _waypointsVisited++;

            //If were going to wait then wait
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                SetDestination();
            }
        }

        //instead if were waiting
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;

                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if(_waypointsVisited > 0)
        {
            ConnectedWaypoint nextWaypoint = _currentWaypoint.nextWaypoint(_previousWaypoint);
            _previousWaypoint = _currentWaypoint;
            _currentWaypoint = nextWaypoint
        }

        Vector3 targetVector = _currentWaypoint.transform.position;
        _navMeshAgent.SetDestination(targetVector);
        _travelling = true;
    }
}
**/