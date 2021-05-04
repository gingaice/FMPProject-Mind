using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC1SimpleMove : MonoBehaviour
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

    private int _rotationSpeed = 180;

    public float chaserTime = 500f;
    public float decreaseSpeed = 50f;
    public Transform Player;

    public bool fovcheck = false;

    public float maxAngle;
    public float maxRadius;

    private bool isInFOV = false;

    public bool checker = false;

    [SerializeField]
    public static bool lockOn = false;

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
        Gizmos.DrawRay(transform.position, (Player.position - transform.position).normalized * maxRadius);

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
            if (_patrolPoints != null && _patrolPoints.Count >= 2)
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
        if (_travelling && _navMeshAgent.remainingDistance <= 1.5f)
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
        if (checker == true)
        {
            fovcheck = true;
            ChangePatrolPoint();
        }
        else
        {
            //ChangePatrolPoint();
            fovcheck = false;
        }

        isInFOV = inFOV(transform, Player, maxAngle, maxRadius);

        if (isInFOV == true)
        {
            if(SanityStuff.isSafe == false)
            {
                checker = true;
            }
            //checker = true;
        }
        else
        {
            checker = false;
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
        if (fovcheck == true)
        {
            lockOn = true;
            //_navMeshAgent.destination = Player.transform.position;
            Vector3 targetDon = Player.transform.position;
            _navMeshAgent.SetDestination(targetDon);

            chaserTime -= Time.deltaTime * decreaseSpeed;
        }
        else
        {
            lockOn = false;
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
