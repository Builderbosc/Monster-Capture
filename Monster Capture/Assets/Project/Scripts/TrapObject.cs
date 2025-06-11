using UnityEngine;

public class TrapObject : MonoBehaviour
{
    Rigidbody rb;
    ScoreManager scoreManager;
    EnemySpawner enemySpawner;

    private bool enemyAgro;

    private void Awake()
    {
        if(!scoreManager)
        {
            scoreManager = FindAnyObjectByType<ScoreManager>();
        }
        if(enemySpawner == null)
        {
            enemySpawner = FindAnyObjectByType<EnemySpawner>();
        }
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AggressiveEnemies>() != null)
        {
            enemyAgro = true;
        }
        else
        {
            enemyAgro = false;
        }
        if (collision.gameObject.CompareTag("Capturable"))
        {
            scoreManager.IncreaseScore(1);
            Destroy(collision.gameObject);
            enemySpawner.SpawnEnemy(enemyAgro);
        }
    }
}
