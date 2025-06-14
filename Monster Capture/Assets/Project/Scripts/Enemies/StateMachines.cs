using System.Collections;
using UnityEngine;


public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Idle,
        Patrol,
        Chasing,
        Cornered,
    }
    public State state;

    [HideInInspector] public GameObject player;

    public float chaseSpeed;
    public bool chasingAggro;

    [HideInInspector] public ChasingBehaviour chasingBehaviour;


    public Vector3 home;
    public Vector3 homeTarget;
    public float homeRadius = 5f;

    public float playerDetectionRadius = 7f;

    [HideInInspector] public float timer;
    public float timerMax;
    public float timerCorneredMax;

    public float corneredSpeed;
    public float timeSpeedyChasing;
    public float timeCorneredRecovery;
    public float exaustedSpeed;
    private float timeChasing;
    private void Awake()
    {
        chasingBehaviour = GetComponent<ChasingBehaviour>();
    }
    private void Start()
    {
        if (!player)
        {
            //Try to get a default target
            player = GameObject.Find("Player");
            chasingBehaviour = GetComponent<ChasingBehaviour>();
        }
        home = transform.position;
        homeTarget = home + new Vector3(Random.Range(-homeRadius, homeRadius), 0, Random.Range(-homeRadius, homeRadius));
        NextState();
    }

    void NextState()
    {
        switch (state)
        {
            case State.Idle:
                StartCoroutine(IdleState());
                break;
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chasing:
                StartCoroutine(ChasingState());
                break;
            case State.Cornered:
                StartCoroutine(CorneredState());
                break;
            default:
                break;
        }
    }

    bool IsFacingPlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();
        float dotResult = Vector3.Dot(directionToPlayer, transform.position);
        return dotResult >= 0.95f  ;
    }

    IEnumerator IdleState()
    {
        Debug.Log("Entering Idle State");
        while (state == State.Idle)
        {
            chasingBehaviour.ChaseTarget(homeTarget, true, chaseSpeed);
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(homeTarget.x, homeTarget.z)) <= 0.01f)
            {
                yield return new WaitForSeconds(Random.Range(0.6f, 2.2f));
                homeTarget = home + new Vector3(Random.Range(-homeRadius, homeRadius), 0, Random.Range(-homeRadius, homeRadius));
                chasingBehaviour.ChaseTarget(homeTarget, true, chaseSpeed);
            }

            if (Vector3.Distance(transform.position , player.transform.position) <= playerDetectionRadius)
            {
                state = State.Patrol;
            }
            yield return null;
        }

        Debug.Log("Exiting Idle State");
        NextState();
    }
    IEnumerator PatrolState()
    {
        Debug.Log("Entering Patrol State");
        while (state == State.Patrol)
        {
            chasingBehaviour.ChaseTarget(player.transform.position, true, 1.2f);

            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.Normalize();
            float dotResult = Vector3.Dot(directionToPlayer, transform.forward);

            if (dotResult >= 0.95f)
            {
                state = State.Chasing;
            }

            yield return null; // Waits for a frame
        }
        Debug.Log("Exiting Patrol State");
        NextState();
    }

    IEnumerator ChasingState()
    {
        Debug.Log("Entering Chasing State");
        while (state == State.Chasing)
        {
            timer += Time.deltaTime;

            chasingBehaviour.ChaseTarget(player.transform.position, chasingAggro, chaseSpeed);
            float wave = Mathf.Sin(Time.time * 20f) * 0.1f + 1f;
            float wave2 = Mathf.Cos(Time.time * 20f) * 0.1f + 1f;
            transform.localScale = new Vector3(wave, wave2, wave);

            if (timer >= timerMax)
            {
                if (!(Vector3.Distance(transform.position, player.transform.position) <= playerDetectionRadius))
                {
                    state = State.Idle;
                }
                
                else
                {
                    state = State.Cornered;
                }
                
            }
            yield return null; // Waits for a frame
        }
        timer = 0;
        Debug.Log("Exiting Chasing State");
        NextState();
    }


    IEnumerator CorneredState()
    {
        timer += Time.deltaTime;
        while (state == State.Cornered)
        {
            CorneredBehaviour();
            yield return null;
            if (timer >= timerCorneredMax)
            {
                if (!(Vector3.Distance(transform.position, player.transform.position) <= playerDetectionRadius))
                {
                    state = State.Idle;
                }
                else
                {
                    state = State.Chasing;
                }
            }
        }
    }
    public virtual void CorneredBehaviour()
    {
        if (timeChasing < timeSpeedyChasing)
        {
            chasingBehaviour.ChaseTarget(player.transform.position, chasingAggro, corneredSpeed);
            timeChasing += Time.deltaTime;
        }

        if (timeChasing > timeSpeedyChasing)
        {
            chasingBehaviour.ChaseTarget(player.transform.position, chasingAggro, exaustedSpeed);
            timeChasing -= Time.deltaTime;
        }
    }
 }