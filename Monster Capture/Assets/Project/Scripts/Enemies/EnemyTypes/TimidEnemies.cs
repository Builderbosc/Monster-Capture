using Unity.VisualScripting;
using UnityEngine;

public class TimidEnemies : StateMachine
{
    [SerializeField] private float TimidSpeed;
    /*
    [SerializeField] private float shrinkScaleHeight;
    [SerializeField] private float shrinkScaleWidth;
    private float startingYScale;
    private float YScale;

    private float startingWScale;
    private float WScale;
    */
    void Awake()
    {
        chasingAggro = false;
        chaseSpeed = TimidSpeed;
        /*
        startingYScale = transform.localScale.y;
        YScale = startingYScale;
        */
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public override void CorneredBehaviour()
    {
        chasingBehaviour.ChaseTarget(player.transform.position, chasingAggro, 0);

        if (YScale > shrinkScaleHeight)
        {
            YScale -= Time.deltaTime;
        }
        else
        {
            YScale = shrinkScaleHeight;
        }

        if (WScale < shrinkScaleWidth)
        {
            WScale += Time.deltaTime;
        }
        else
        {
            WScale = shrinkScaleWidth;
        }
            transform.localScale = new Vector3(transform.localScale.x, YScale, transform.localScale.z);
    }
    */
}
