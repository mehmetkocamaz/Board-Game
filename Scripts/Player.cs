using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  
{
    public int baseLevelPlayer = 1;
    public int[] cardInventory= new int[18];
    public List<Card> cardList = new List<Card>();
    public int[] usedCards = new int[6];
    public int strength = 1;
    public Transform playerLocation;

    public Player(Transform playerLocation)
    {
        this.playerLocation = playerLocation;
    }
    public void AddNewCard(Card card)
    {
        cardList.Add(card);
    }
    public void AddNewEmptyCard()
    {
        cardList.Add(new Card());
    }

    public Card getCardWithID(int ID)
    {
        var card = cardList.Find(card => card.ID == ID);
        return card;
    }

    public Card getCardsWithIndex(int index)
    {
        return cardList[index];
    }
    public void RemoveCard(Card card)
    {
        cardList.Remove(card);
    }
    public void RemoveCardWithIndex(int index)
    {
        cardList.RemoveAt(index);
    }
    /// <summary>
    /// Burada önce deðiþtirilicek index deðerini ver sonra card deðerini ver.
    /// </summary>
    public void UpdateCardWithIndex(int index,Card card)
    {
        cardList[index] = card;
    }

    public void DisplayCards()
    {
        Debug.Log(cardList.Count);
        foreach (var item in cardList)
        {
            if (item != null)
            {
                int index = cardList.IndexOf(item);
                Debug.Log($"Index: {index} ID: {item.ID}");
            }
            else
            {
                Debug.Log("EMPTY");
            }
        }
    }
}
