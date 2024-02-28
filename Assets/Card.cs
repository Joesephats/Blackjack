using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    string suit;
    int value;
    int cardSpriteIndex;
    bool inHand = false;
    bool revealed = false;

    public string Suit 
    {
        get { return suit; }
    }

    public int Value
    {
        get { return value; }
    }

    public int CardSpriteIndex
    {
        get { return cardSpriteIndex; }
    }

    public bool InHand
    {
        get { return inHand; }
        set { inHand = value; }
    }

    public bool Revealed
    {
        get { return revealed; }
        set { revealed = value; }
    }

    public Card(string newSuit, int newValue, int newSpriteIndex) 
    {
        suit = newSuit;
        value = newValue;
        cardSpriteIndex = newSpriteIndex;
    }
}
