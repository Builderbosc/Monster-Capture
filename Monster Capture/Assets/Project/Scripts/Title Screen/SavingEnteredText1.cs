using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SavingEnteredText : MonoBehaviour
{
    [SerializeField] private Button playButton;
    public static string nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //nameText = inputText.GetComponent<TMP_InputField>().text;
    }

    public void SaveText(string InputText)
    {
        if (InputText != String.Empty)
        {
            playButton.interactable = true;
            nameText = InputText;
            Debug.Log(nameText);
        }
        else
        {
            nameText = String.Empty;
            playButton.interactable = false;
        }
    }
}
