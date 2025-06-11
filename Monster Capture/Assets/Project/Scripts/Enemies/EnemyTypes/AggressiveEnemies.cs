using UnityEngine;

public class AggressiveEnemies : StateMachine
{
    [SerializeField] private float aggroSpeed;
    void Awake()
    {
        chasingAggro = true;
        chaseSpeed = aggroSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
