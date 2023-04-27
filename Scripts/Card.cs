using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int ID { get; set; }
    public CardRaces Race { get; set; }
    public CardType Type { get; set; }
    private int price;
    public int Price
    {
        get
        {
            return price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Price 0'dan d���k olamaz");
            }
            if (value > 4)
            {
                throw new ArgumentOutOfRangeException("Price 4'den b�y�k olamaz");
            }
            price = value;
        }
    }
    private int strength;
    public int Strength
    {
        get
        {
            return strength;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Strength 0'dan d���k olamaz");
            }
            if (value > 6)
            {
                throw new ArgumentOutOfRangeException("Strength 6'dan b�y�k olamaz");
            }
            strength = value;
        }
    }

    public Card()
    {

    }
    public Card(int ID, CardRaces Race, CardType Type, int Price = 0, int Strength = 0)
    {
        this.ID = ID;
        this.Race = Race;
        this.Type = Type;
        this.Price = Price;
        this.Strength = Strength;
    }

}


public enum CardRaces
{
    Insan,
    Kahin,
    B�y�c�,
    Saman,
    NoRace
}
public enum CardType
{
    Kask,
    Z�rh,
    �izme,
    TekEl,
    �iftEl,
    NoType,
}
