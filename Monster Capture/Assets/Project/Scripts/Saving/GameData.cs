using UnityEditor.Build.Player;
using UnityEngine;

[System.Serializable]

public class HighScoreData
{
    public int[] scores;
    public string[] names;

    // Constructor
    public HighScoreData()
    {
        scores = new[] { 99, 10, 1 };
        names = new[] { "Andrew", "Tom", "Steve" };
    }

    // Overloaded Constructor
    public HighScoreData(int[] scores, string[] names)
    {
        this.scores = scores;
        this.names = names;

    }
}

public class Float3
{
    public float x, y, z;
    public void FromVector(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}
