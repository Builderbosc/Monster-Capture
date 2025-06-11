using UnityEngine;
using UnityEngine.AI;
public class ChasingBehaviour : MonoBehaviour
{
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private NavMeshAgent agent;


    private float speed;

    private int ChasingIndex = 1;
    public bool isChasing = false;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    public void ChaseTarget(Vector3 Target, bool chasingAggro, float Speed)
    {
        
        ChasingIndex = chasingAggro ? ChasingIndex = 1 : ChasingIndex = -1;

        agent.speed = Speed;
        if (chasingAggro)
        {
            agent.destination = Target;
        }
        else
        {
            Vector3 directionAwayFromPlayer = transform.position - Target;
            directionAwayFromPlayer = directionAwayFromPlayer.normalized * 8f;
            agent.destination = transform.position + directionAwayFromPlayer;
        }
    }

    
    // Update is called once per frame
    void Update()
    {

    }
}
