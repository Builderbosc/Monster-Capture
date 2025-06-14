using UnityEditor.Overlays;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private SceneLoader loader;
    private ScoreManager scoreManager;
    private EnteredName text;

    private bool hasSaved;

    private string userName;

    [SerializeField] private float timerMax;
    private float timerCurrent;

    public int sceneLoadOnLoss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasSaved = false;
        loader = GetComponent<SceneLoader>();
        scoreManager = GetComponentInChildren<ScoreManager>();
        text = FindAnyObjectByType<EnteredName>();
        timerCurrent = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCurrent > 0)
        {
            timerCurrent -= Time.deltaTime;
        }


        if (TimerFinish() && hasSaved)
        {
            hasSaved = true;
            TimerEnd();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            timerCurrent = 0;
        }
    }

    public void loseTime(float timeLoss)
    {
        timerCurrent -= timeLoss;
    }

    public float GetTimerPercent()
    {
        return timerCurrent / timerMax;
    }

    public string GetTimeText()
    {
        return ((int) timerCurrent).ToString();
    }
    public bool TimerFinish()
    {
        return timerCurrent <= 0;
    }


    public void TimerEnd()
    {
        if (text.GetName() == string.Empty)
        {
            userName = new string("Annonymous");
        }
        else
        {
            userName = text.GetName();
        }
        scoreManager.AddHighScore(userName, scoreManager.currentScore);
        
    }
}
