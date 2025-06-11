using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public float xRange;
    public float zRange;

    private Vector3 spawnPoint;


    private GameObject playerPos;

    [Tooltip("The Prefab of the agro Enemys.")]
    [SerializeField] private GameObject AgroEnemy;
    [Tooltip("The Prefab of the timid Enemys.")]
    [SerializeField] private GameObject TimidEnemy;

    //Debug Var
    [Tooltip("Determines the kind of enemy that sp[awns when Numlock is pressed. For debugging purposses.")]
    [SerializeField] private bool isAgro;

    [SerializeField] private int AgroEnemiesMax;
    [Tooltip("The ammount of Timid Enemies spawned by the start of the game.")]
    [SerializeField] private int TimidEnemiesMax;

    private int currentAgroCount;
    private int currentTimidCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!playerPos)
        {
            //Try to get a default textManager
            playerPos = GameObject.FindGameObjectWithTag("Player");
        }
        for (int i = 0; i <= AgroEnemiesMax; i++)
        {
            SpawnEnemy(true);
        }

        for (int i = 0;i <= TimidEnemiesMax;i++)
        {
            SpawnEnemy(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Numlock))
        {
            SpawnEnemy(isAgro);
        }


    }

    public void SpawnEnemy(bool isEnemyAgro)
    {
        spawnPoint = new Vector3(Random.Range(-xRange, xRange), 1, Random.Range(-zRange, zRange));        if(isEnemyAgro)
        {
            Instantiate(AgroEnemy, spawnPoint, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Instantiate(TimidEnemy, spawnPoint, new Quaternion(0, 0, 0, 0));
        }    
    }
}
