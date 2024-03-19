using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class Blackjack : MonoBehaviour
{
    List<Card> deck = new List<Card>();
    [SerializeField] Sprite[] cardSpriteSheet;

    Hand playerHand;
    [SerializeField] GameObject[] playerHandSprites = new GameObject[8];
    Hand dealerHand;
    [SerializeField] GameObject[] dealerHandSprites = new GameObject[8];

    [SerializeField] GameObject hitButton;
    [SerializeField] GameObject standButton;

    [SerializeField] TMP_Text playerHandValueText;
    [SerializeField] TMP_Text dealerHandValueText;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    int playerHandValue = 0;
    int dealerHandValue = 0;

    bool gameOver;
    bool canHit;

    private void Awake()
    {
        playerHand = new Hand();
        dealerHand = new Hand();

        gameOver = false;
        canHit = true;

        playerHandValueText.text = $"{playerHandValue}";
        dealerHandValueText.text = $"{dealerHandValue}";
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateFiftyTwo();
        DebugDeck();

        ShuffleDeck();
        DebugDeck();

        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHand.Cards.Count == 7)
        {
            canHit = false;
        }

        if (!canHit)
        {
            hitButton.gameObject.GetComponent<Button>().interactable = false;
        }

    }

    void CreateFiftyTwo()
    {
        string clubs = "clubs";
        string spades = "spades";
        string diamonds = "diamonds";
        string hearts = "hearts";

        int deckIndex = 0;


        deck.Add(new Card(clubs, 11, deckIndex));
        deckIndex++;
        deck.Add(new Card(clubs, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(clubs, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(clubs, 10, deckIndex));
        deckIndex++;

        for (int j = 10; j >= 2; j--)
        {
            deck.Add(new Card(clubs, j, deckIndex));
            deckIndex++;
        }

        deck.Add(new Card(spades, 11, deckIndex));
        deckIndex++;
        deck.Add(new Card(spades, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(spades, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(spades, 10, deckIndex));
        deckIndex++;

        for (int j = 10; j >= 2; j--)
        {
            deck.Add(new Card(spades, j, deckIndex));
            deckIndex++;
        }

        deck.Add(new Card(diamonds, 11, deckIndex));
        deckIndex++;
        deck.Add(new Card(diamonds, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(diamonds, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(diamonds, 10, deckIndex));
        deckIndex++;

        for (int j = 10; j >= 2; j--)
        {
            deck.Add(new Card(diamonds, j, deckIndex));
            deckIndex++;
        }

        deck.Add(new Card(hearts, 11, deckIndex));
        deckIndex++;
        deck.Add(new Card(hearts, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(hearts, 10, deckIndex));
        deckIndex++;
        deck.Add(new Card(hearts, 10, deckIndex));
        deckIndex++;

        for (int j = 10; j >= 2; j--)
        {
            deck.Add(new Card(hearts, j, deckIndex));
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
        for (int i = 0; i < deck.Count; i++)
        {
            Debug.Log($"suit: {deck[i].Suit}, value: {deck[i].Value}, index: {deck[i].CardSpriteIndex}");
        }
    }

    void Deal()
    {
        playerHand.AddCard(DrawCard(deck));
        dealerHand.AddCard(DrawCard(deck));
        dealerHand.Cards[0].Revealed = false;
        playerHand.AddCard(DrawCard(deck));
        dealerHand.AddCard(DrawCard(deck));

        Debug.Log("Player Hand");
        for (int i = 0; i < playerHand.Cards.Count; i++)
        {
            Debug.Log(playerHand.Cards[i].Value);
        }

        Debug.Log("Dealer Hand");
        for (int i = 0; i < dealerHand.Cards.Count; i++)
        {
            Debug.Log(dealerHand.Cards[i].Value);
        }

        UpdateHandUI(playerHand, playerHandSprites, playerHandValueText);
        UpdateHandUI(dealerHand, dealerHandSprites, dealerHandValueText);
    }
    Card DrawCard(List<Card> deck)
    {
        int drawIndex = Random.Range(0, deck.Count);
        Debug.Log($"Drawing Card at index: {drawIndex}");
        Card newCard = deck[drawIndex];
        deck.RemoveAt(drawIndex);
        Debug.Log($"Removing Card at index: {drawIndex}");

        Debug.Log($"Drawn Card Index: {newCard.CardSpriteIndex}");
        return newCard;
    }
    public void Hit()
    {
        playerHand.AddCard(DrawCard(deck));
        UpdateHandUI(playerHand, playerHandSprites, playerHandValueText);

        if (CheckBust(playerHand))
        {
            canHit = false;
            loseScreen.SetActive(true);
            Debug.Log("BUST");
            gameOver = true;
        }
    }

    public void Stand()
    {
        canHit = false;
        dealerHand.Cards[0].Revealed = true;
        dealerHandValueText.gameObject.SetActive(true);

        UpdateHandUI(playerHand, playerHandSprites, playerHandValueText);

        DealOut();

        if (DidPlayerWin())
        {
            winScreen.SetActive(true);
            Debug.Log("Player Win");
        }
        else
        {
            loseScreen.SetActive(true);
            Debug.Log("Player Lose");
        }

        standButton.gameObject.GetComponent<Button>().interactable = false;
    }
    bool CheckBust(Hand hand)
    {
        if (hand.GetHandValue() > 21)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void DealOut()
    {
        dealerHand.Cards[0].Revealed = true;
        dealerHandValueText.gameObject.SetActive(true);

        UpdateHandUI(dealerHand, dealerHandSprites, dealerHandValueText);

        while (dealerHand.GetHandValue() < 17)
        {
            dealerHand.AddCard(DrawCard(deck));
            UpdateHandUI(dealerHand, dealerHandSprites, dealerHandValueText);
        }
    }
    bool DidPlayerWin()
    {
        if (CheckBust(dealerHand))
        {
            if (!gameOver)
            {
                return true;
            }
            return false;
        }
        else if (gameOver)
        {
            return false;
        }
        else if (playerHand.GetHandValue() > dealerHand.GetHandValue())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void UpdateHandUI(Hand hand, GameObject[] handSpritesArray, TMP_Text valueUI)
    {
        for (int i = 0; i < hand.Cards.Count; i++)
        {
            if (hand.Cards[i] == null)
            {
                continue;
            }
            else if (hand.Cards[i].Revealed)
            {
                int spriteIndex = hand.Cards[i].CardSpriteIndex;
                GameObject uiObject = handSpritesArray[i];
                uiObject.GetComponent<SpriteRenderer>().sprite = cardSpriteSheet[spriteIndex];
            }
            else if (!(hand.Cards[i].Revealed))
            {
                GameObject uiObject = handSpritesArray[i];
                uiObject.GetComponent<SpriteRenderer>().sprite = cardSpriteSheet[52];
            }
        }

        valueUI.text = $"{hand.GetHandValue()}";
    }
}
