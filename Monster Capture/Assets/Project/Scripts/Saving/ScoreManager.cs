using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text uiTextScore;
    public TMP_Text uiTextHighscore;

    public GameObject scoresParent;
    public TMP_Text scorePrefab;
    public GameObject player;

    private List<string> names = new List<string>();
    private List<int> scores = new List<int>();
    public int maxScoresCount = 10;
    public int currentScore = 0;


    public int CurrentScore
    {
        get => currentScore;
        private set
        {
            currentScore = value;
            uiTextScore.text = "Score: " + currentScore;
        }
    }


    public void Awake()
    {
        HighScoreData data = JasonSaveLoad.Load();
        scores = data.scores.ToList();
        names = data.names.ToList();
        RefreshScoreDisplay();
        CleanUpHighScores();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IncreaseScore(int amount)
    {
        currentScore += amount;
        uiTextScore.text = "Score: " + currentScore;
    }

    public void OnDestroy()
    {
        AddHighScore(CurrentScore);
        HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
        JasonSaveLoad.Save(data);
    }
    public void RefreshScoreDisplay()
    {
        DestroyAllChildren(scoresParent);
        for (int i = 0; i < scores.Count; i++)
        {
            TMP_Text uiText = Instantiate(scorePrefab, scoresParent.transform);
            uiText.text = names[i] + " " + scores [i];
        }
    }

    private void DestroyAllChildren(GameObject parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>(true);
        for (int i = children.Length -1; i >= 0; i--)
        {
            if (children[i] == parent.transform)
            {
                return;
            }
            else
            {
                Destroy(children[i].gameObject);
            }

        }
        
    }
    public void AddHighScore(int score)
    {
        string[] possibleNames = new[] { "Jim", "JimMan", "IdeaMan", "GoodMan", "SoupMan", "GhostMan", "HatMan", "RockMan","Meg","MegWoman","BadMan" };
        string randomName = possibleNames[Random.Range(0, possibleNames.Length)];

        AddHighScore(randomName, score);
    }

    public void AddHighScore(string name, int score)
    {

        CleanUpHighScores();
        for (int i = 0; i < scores.Count; i++)
        {
            if (score > scores[i])
            {
                scores.Insert(i, score);
                names.Insert(i, name);

                return;
            }
        }

        if (scores.Count < maxScoresCount)
        {
            scores.Add(score);
            names.Add(name);
        }
    }


    public void CleanUpHighScores()
    {
        for (int i = maxScoresCount; i < scores.Count; i++)
        {
            names.RemoveAt(i);
            scores.RemoveAt(i);
        }
    }
}

