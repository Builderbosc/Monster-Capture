using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().gameObject;

        ScoreManager.instance.RefreshScoreDisplay();
    }

    void Update()
    {
        if (player.transform.position.y < -10)
        {
            ScoreManager.instance.AddHighScore(ScoreManager.instance.CurrentScore);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}