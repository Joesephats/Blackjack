using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand
{
    private List<Card> cards;


    public List<Card> Cards { get { return cards;} }

    public Hand()
    {
        cards = new List<Card>(8);
    }
    public void AddCard(Card newCard)
    {
        cards.Add(newCard);
        newCard.Revealed = true;
    }

    public int GetHandValue()
    {
        int handValue = 0;

        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].Value != 11)
            {
                handValue += cards[i].Value;
            }
        }
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].Value == 11)
            {
                if (handValue + cards[i].Value > 21)
                {
                    handValue += 1;
                }
                else
                {
                    handValue += 11;
                }
            }
        }
        return handValue;
    }
}
