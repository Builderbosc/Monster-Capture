using UnityEngine;

public class TimeReductionReciever : MonoBehaviour
{
    private Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = FindAnyObjectByType(typeof(Timer)) as Timer;
    }

    // Update is called once per frame
    public void TakeTimeReduction(float timeLoss)
    {
        timer.loseTime(timeLoss);
    }    
}
