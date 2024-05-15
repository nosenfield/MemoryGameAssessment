using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main is the entry point for our game.
/// </summary>
public class Main : MonoBehaviour
{
    [SerializeField] private const int MIN_PAIRS = 2; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private const int MAX_PAIRS = 10; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private int numCardPairs; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private GameObject cardPrefab; // a default card object to clone
    [SerializeField] private RectTransform cardContainer; // the visual container for cards
    [SerializeField] private CardDesignLibrary cardDesignLibrary; // the visual container for cards
    private int numCardsRemaining;

    void Awake()
    {
        NumPairInput.NumPairUpdate += UpdateNumPairs;
        NewGameButton.StartNewGameClicked += StartNewGame;
    }

    void UpdateNumPairs(int numPairs)
    {
        Debug.Log($"UpdateNumPairs: {numPairs}");

        // TODO: instead of forcing a valid value, validate input and issue a message to user in case of conflict
        numCardPairs = Math.Clamp(numPairs, MIN_PAIRS, MAX_PAIRS);
    }

    void StartNewGame()
    {
        Debug.Log($"StartNewGame()");

        // destroy the existing cards
        for (int i = cardContainer.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(cardContainer.GetChild(i).gameObject);
        }

        // create new cards from the prefab
        List<GameObject> cards = new List<GameObject>();
        for (int i = 0; i < numCardPairs; i++)
        {
            // this could be done in an i<2 for loop, but this feels more readable
            GameObject cardA = GameObject.Instantiate(cardPrefab, cardContainer);
            cardA.GetComponentInChildren<CardDisplayer>().SetDesign(cardDesignLibrary.Faces[i]);
            cards.Add(cardA);

            GameObject cardB = GameObject.Instantiate(cardPrefab, cardContainer);
            cardB.GetComponentInChildren<CardDisplayer>().SetDesign(cardDesignLibrary.Faces[i]);
            cards.Add(cardB);
        }

        // shuffle cards
        GameObject[] cardArr = cards.ToArray();
        Shuffle<GameObject>(cardArr);
        numCardsRemaining = numCardPairs;

        // set cards to their starting states
        for (int i = 0; i < cardArr.Length; i++)
        {
            cardArr[i].transform.SetSiblingIndex(i); // reorders the cards visually as per the shuffle
        }

    }

    void Shuffle<T>(T[] array)
    {
        System.Random rng = new System.Random();
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void CardSelectListener()
    {

    }
}