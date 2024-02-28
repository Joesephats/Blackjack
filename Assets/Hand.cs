using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hand
{
    private List<Card> cards;

    public void Check(Card newCard)
    {
        cards.Add(newCard);
    }
}
