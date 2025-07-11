using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerUI : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] private CameraOrbit cameraOrbit;

    [SerializeField] private Image timerBar;

    [SerializeField] private TMP_Text timerText;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject losePannel;

    // Update is called once per frame
    void Update()
    {
        timerBar.fillAmount = timer.GetTimerPercent();
        timerText.text = timer.GetTimeText();
        if (timer.TimerFinish())
        {
            cameraOrbit.gameObject.SetActive(false);
            losePannel.SetActive(true);
            player.SetActive(false);
        }
    }
}