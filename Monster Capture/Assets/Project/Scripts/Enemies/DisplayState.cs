using UnityEngine;
using System;
using TMPro;

public class DisplayState : MonoBehaviour
{
    [SerializeField] private StateMachine stateMachine;
    private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = stateMachine.state.ToString();
    }
}
