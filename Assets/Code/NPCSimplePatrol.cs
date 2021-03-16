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
    float _totalWaitTime = 5f;

    //the probability of switching direction
    [SerializeField]
    float _switchProbability = 0.5f;

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

    private static int _rotationSpeed = 40;

    public float chaserTime = 500f;
    public float chasedTimer = 100;
    public float decreaseSpeed = 50f;
    public Transform Player;
    public bool fovcheck = false;
    

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
                
                ChangePatrolPoint();
                SetDestination();
                _patrolWaiting = false;
                //Chasing();
            }

            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }

        if (FOVDetection.lockOn == true)
        {
            /**
            if(isChasing == true)
            {
                StartCoroutine(Chasing());
            }
            **/

            fovcheck = true;

            if(fovcheck == true)
            {
                _navMeshAgent.destination = Player.transform.position;
                chaserTime -= Time.deltaTime * decreaseSpeed;

            }
        }
        else
        {

            fovcheck = false;
        }
    }

    /**
    private void Chasing()
    {
        chasedTimer += Time.deltaTime * decreaseSpeed;
        _patrolWaiting = false;
        //_navMeshAgent.destination = Player.transform.position;
        if(chasedTimer >= 5f)
        {
            fovcheck = false;
        }
    }
    **/
    

    private void SetDestination()
    {
        if (chaserTime <= 460)
        {
            //Chasing();
            chasedTimer += Time.deltaTime * decreaseSpeed;

            _patrolWaiting = false;

            if (chasedTimer >= 100f)
            {
                fovcheck = false;
            }
        }
        else
        {
            if (_patrolPoints != null)
            {
                Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
                _navMeshAgent.SetDestination(targetVector);
                _travelling = true;
            }
        }
        /**
        if (_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
        **/
    }


    // this selects a new patrol point in the list but also has a small chanc for it to go a different way#
    private void ChangePatrolPoint()
    {
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
    }
}
