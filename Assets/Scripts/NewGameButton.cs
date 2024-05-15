using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// NewGameButton is a component for the new game button supplied to the user for defining how many pairs to start a new game with.
/// When the player clicks this button we emit an event.
/// </summary>
public class NewGameButton : MonoBehaviour
{
    public static Action StartNewGameClicked;
    [SerializeField] private Button startNewGameButton; // provide the Button component dependency via the editor

    void Awake()
    {
        // TODO: remove listener on destroy
        startNewGameButton.onClick.AddListener(OnClickListener);
    }
    void OnClickListener()
    {
        StartNewGameClicked.Invoke();
    }
}