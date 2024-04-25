using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameInputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    public void SaveName()
    {
        string playerName = nameInputField.text;
        MainManager.Instance.currentName = playerName;
    }
}
