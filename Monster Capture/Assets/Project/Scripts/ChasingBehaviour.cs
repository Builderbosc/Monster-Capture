using UnityEngine;
public class ChasingBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool chasingAggro;

    [SerializeField] private StateMachine stateMachine;

    private float speed;

    private float ObjX;
    private float ObjY;
    private float ObjZ;

    private Vector3 ObjTargetPos;

    private int ChasingIndex = 1;

    void Start()
    {
        speed = stateMachine.chaseSpeed;
        chasingAggro = stateMachine.chasingAggro;
        enabled = false;   
    }
    // Update is called once per frame
    void Update()
    {
        ChasingIndex = chasingAggro ? ChasingIndex = 1 : ChasingIndex = -1;

        ObjX = ((target.transform.position.x - transform.position.x) * ChasingIndex);
        ObjZ = ((target.transform.position.z - transform.position.z) * ChasingIndex);
        ObjY = 0;
        ObjTargetPos = new Vector3(ObjX, ObjY, ObjZ) * speed;

        transform.position += (Vector3.Normalize(ObjTargetPos) * speed * Time.deltaTime);

        if (transform.position.y <= 0)
        {
            transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
        }
    }
}
