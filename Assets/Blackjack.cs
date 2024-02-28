using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : MonoBehaviour
{
    Card[] deck = new Card[52];
    [SerializeField] Sprite[] cardSprites;


    // Start is called before the first frame update
    void Start()
    {
        CreateFiftyTwo();
        DebugDeck();
        ShuffleDeck();
        DebugDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateFiftyTwo()
    {
        string clubs = "clubs";
        string spades = "spades";
        string diamonds = "diamonds";
        string hearts = "hearts";

        int deckIndex = 0;

        deck[deckIndex] = new Card(clubs, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(clubs, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(clubs, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(clubs, 10, deckIndex);
        deckIndex++;

        for (int j = 10; j >= 2; j++)
        {
            deck[deckIndex] = new Card(clubs, j, deckIndex);
            deckIndex++;
        }

        deck[deckIndex] = new Card(spades, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(spades, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(spades, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(spades, 10, deckIndex);
        deckIndex++;

        for (int j = 10; j >= 2; j++)
        {
            deck[deckIndex] = new Card(spades, j, deckIndex);
            deckIndex++;
        }

        deck[deckIndex] = new Card(diamonds, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(diamonds, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(diamonds, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(diamonds, 10, deckIndex);
        deckIndex++;

        for (int j = 10; j >= 2; j++)
        {
            deck[deckIndex] = new Card(diamonds, j, deckIndex);
            deckIndex++;
        }

        deck[deckIndex] = new Card(hearts, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(hearts, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(hearts, 10, deckIndex);
        deckIndex++;
        deck[deckIndex] = new Card(hearts, 10, deckIndex);
        deckIndex++;

        for (int j = 10; j >= 2; j++)
        {
            deck[deckIndex] = new Card(hearts, j, deckIndex);
            deckIndex++;
        }
    }

    void ShuffleDeck()
    {
        for (int j = 0; j < 52; j++)
        {
            int randomIndex = Random.Range(0, 52);
            Card tempCard = deck[j];
            deck[j] = deck[randomIndex];
            deck[randomIndex] = tempCard;
        }
    }

    void DebugDeck()
    {
        for (int i = 0; i < deck.Length; i++)
        {
            Debug.Log($"suit: {deck[i].Suit}, value: {deck[i].Value}, index: {deck[i].CardSpriteIndex}");
        }
    }
}
