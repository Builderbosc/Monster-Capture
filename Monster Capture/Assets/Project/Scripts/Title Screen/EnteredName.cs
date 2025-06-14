using Unity.VisualScripting;
using UnityEngine;

public class EnteredName : MonoBehaviour
{
    public static string nameText;
    public void SaveName(string name)
    {
        nameText = name;
    }

    public string GetName()
    {
        return nameText;
    }
}
