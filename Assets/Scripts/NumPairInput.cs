using System;
using TMPro;
using UnityEngine;

/// <summary>
/// NumPairInput is a component for the text input field supplied to the user for defining how many pairs to start a new game with.
/// Whenthe player makes changes to this number we emit an event
/// </summary>
public class NumPairInput : MonoBehaviour
{
    public static Action<int> NumPairUpdate;
    [SerializeField] private TMP_InputField inputField;


    void Awake()
    {
        // TODO: remove listener on destroy
        inputField.onValueChanged.AddListener(OnValueChangedListener);
    }
    void OnValueChangedListener(string text)
    {
        int.TryParse(text, out int value);
        NumPairUpdate.Invoke(value);
    }
}