using UnityEngine;

public class TimidEnemies : StateMachine
{
    [SerializeField] private float TimidSpeed;
    void Awake()
    {
        chasingAggro = false;
        chaseSpeed = TimidSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
