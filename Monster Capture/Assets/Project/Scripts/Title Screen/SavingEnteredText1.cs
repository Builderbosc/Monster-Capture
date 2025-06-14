using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SavingEnteredText : MonoBehaviour
{
    [SerializeField] EnteredName enteredName;
    [SerializeField] private Button playButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.interactable = false;
    }

    public void SaveText(string InputText)
    {
        if (InputText != String.Empty)
        {
            playButton.interactable = true;
            enteredName.SaveName(InputText);
            Debug.Log(InputText);
        }
        else
        {
            InputText = String.Empty;
            playButton.interactable = false;
        }
    }
}
