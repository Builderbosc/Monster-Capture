using UnityEngine;

public class TimidEnemies : StateMachine
{
    [SerializeField] private float TimidSpeed;
    void Awake()
    {
        chasingAggro = false;
        chaseSpeed = TimidSpeed;
    }
}
