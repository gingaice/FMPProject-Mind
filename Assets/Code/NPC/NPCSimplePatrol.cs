using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSimplePatrol : MonoBehaviour
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

    //the list of all patrol nodes to visit
    [SerializeField]
    List<Waypoint> _patrolPoints;

    //private variables for base behaviour
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;

    private static int _rotationSpeed = 80;

    public float chaserTime = 500f;
    public float decreaseSpeed = 50f;
    public Transform Player;
    public bool fovcheck1 = false;


    // Start is called before the first frame update
    void Start()
    {
        //this is too find the navmesh agent on the object that you put it on
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            Debug.Log("the don is here " + gameObject.name);
            //this is to find the patrol points that i will be putting into the scene for the ai to go too
            if(_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("insufficient patrol points for basic patrolling behaviour");
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //checking to see if were close to the destination that we want to go too
        if(_travelling && _navMeshAgent.remainingDistance <= 1.5f)
        {
            _travelling = false;
            _patrolWaiting = true;

            //If were going to wait then wait
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
                //Chasing();
            }
        }

        //instead if were waiting
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;
                _patrolWaiting = false;

                ChangePatrolPoint();
                SetDestination();
                //_patrolWaiting = false;
                //Chasing();
            }

            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }
        //to make sure that the ai can see currently not working with more than one
        if (FOVDetection.lockOn1 == true)
        {
            fovcheck1 = true;
            ChangePatrolPoint();
        }
        else
        {
            //ChangePatrolPoint();
            fovcheck1 = false;
        }
        

        //if (fovcheck == true)
        //{
            //chasePlayer();
            /**
            _navMeshAgent.destination = Player.transform.position;
            chaserTime -= Time.deltaTime * decreaseSpeed;
            _patrolWaiting = true;
            **/
        //}
        //else
        //{
            //chaserTime += Time.deltaTime * decreaseSpeed;
            //chaserTime = 500;
        //}


    }
    /**
    private void chasePlayer()
    {
        _travelling = true;
        _navMeshAgent.destination = Player.transform.position;
        chaserTime -= Time.deltaTime * decreaseSpeed;
    }
    **/
    private void SetDestination()
    {
        if (chaserTime <= 490)
        {
            //_waiting = true;
        }
        else
        {
            chaserTime = 500;
            if (_patrolPoints != null)
            {
                Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
                _navMeshAgent.SetDestination(targetVector);
                _travelling = true;
            }
        }
    }


    // this selects a new patrol point in the list but also has a small chanc for it to go a different way#
    private void ChangePatrolPoint()
    {
        if(fovcheck1 == true)
        {
            //_navMeshAgent.destination = Player.transform.position;
            Vector3 targetDon = Player.transform.position;
            _navMeshAgent.SetDestination(targetDon);

            chaserTime -= Time.deltaTime * decreaseSpeed;
        }
        else
        {
            chaserTime = 500;
            //this uses unity random featuere to make the npc go either forwards or backwards
            if (UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
            {
                _patrolForward = !_patrolForward;
            }

            if (_patrolForward)
            {
                //this checks to see how many points there are left and if it has finished the cycle and if it has it resets the cycle

                _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
            }
            else
            {
                if (--_currentPatrolIndex < 0)
                {
                    _currentPatrolIndex = _patrolPoints.Count - 1;
                }
            }
        }
        /**
        //this uses unity random featuere to make the npc go either forwards or backwards
        if (UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward)
        {
            //this checks to see how many points there are left and if it has finished the cycle and if it has it resets the cycle

            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            if(--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
        **/
    }
}
