using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main is the entry point for our game.
/// </summary>
public class Main : MonoBehaviour
{
    [SerializeField] private const int MIN_PAIRS = 2; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private const int MAX_PAIRS = 10; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private int playerObservationDelayMilliseconds = 2000; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private int numCardPairs; // expose this field in the editor so that we can set defaults and observe changes
    [SerializeField] private GameObject cardPrefab; // a default card object to clone
    [SerializeField] private RectTransform cardContainer; // the visual container for cards
    [SerializeField] private CardDesignLibrary cardDesignLibrary; // the visual container for cards
    [SerializeField] private Card firstCard; // the visual container for cards
    private int numCardsRemaining;

    private bool waitingForAnimation;

    void Awake()
    {
        NumPairInput.NumPairUpdate += UpdateNumPairs;
        NewGameButton.StartNewGameClicked += StartNewGame;
        Card.CardClicked += CardClickHandler;
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

        // turn on the automatic layout component
        cardContainer.GetComponentInChildren<GridLayoutGroup>().enabled = true;

        // create new cards from the prefab
        List<GameObject> cards = new List<GameObject>();
        for (int i = 0; i < numCardPairs; i++)
        {
            // this could be done in an i<2 for loop, but this feels more readable
            GameObject cardA = GameObject.Instantiate(cardPrefab, cardContainer);
            cardA.GetComponentInChildren<Card>().InitializeCard(i, cardDesignLibrary.Faces[i], cardDesignLibrary.Backings[0]);
            cards.Add(cardA);

            GameObject cardB = GameObject.Instantiate(cardPrefab, cardContainer);
            cardB.GetComponentInChildren<Card>().InitializeCard(i, cardDesignLibrary.Faces[i], cardDesignLibrary.Backings[0]);
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

        // Wait one frame, then disable the automatic layout component
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForEndOfFrame();
            cardContainer.GetComponentInChildren<GridLayoutGroup>().enabled = false;
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

    async void CardClickHandler(Card card)
    {
        Debug.Log($"CardClickHandler()");

        if (waitingForAnimation)
        {
            Debug.LogWarning($"holding for animations");
            return;
        }

        // show new card
        card.ShowFace();

        // perform  matching logic
        if (firstCard == null)
        {
            Debug.Log($"first card is {card.ID}");
            waitingForAnimation = false;
            firstCard = card;
        }
        else if (firstCard == card)
        {
            // clicked the already flipped card
            // do nothing 
            Debug.LogWarning($"first card clicked twice");
            return;
        }
        else
        {
            waitingForAnimation = true;
            Debug.Log($"second card is {card.ID}");

            // wait 2 seconds for player to observe the cards
            await Task.Delay(playerObservationDelayMilliseconds);

            Debug.Log($"is a match: {card.ID == firstCard.ID}");

            if (card.ID == firstCard.ID)
            {
                // it's a match
                GameObject.Destroy(firstCard.gameObject);
                GameObject.Destroy(card.gameObject);

                firstCard = null;
            }
            else
            {
                // not a match
                firstCard.ShowBack();
                card.ShowBack();

                firstCard = null;
            }

            waitingForAnimation = false;
        }
    }
}