//Author: Josue Rosales
//Project: Deck of Cards
//The purpose of this class is to represent a single Card.

using System;
namespace Deck_of_Cardsx
{
    public class Card
    {

        public int Number { get; set; }//they are still private but with automatic properties, it doesn't need to be defined.
        public String Suit { get; set; }

        public Card()//Constructor
        {
            this.Number = 0;
            this.Suit = "";
        }
    }//end of Class.
}//end namespace.
