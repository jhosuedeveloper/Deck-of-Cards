//Author: Josue Rosales
//Project: Deck of Cards
//The purpose of this class is to run the program Deck of Cards.

using System;
using System.Collections;
namespace Deck_of_Cardsx
{
    //Class Program is the main class.
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck game = new Deck();//creating object deck
            game.StartGame(); //runnin the whole game with this function.
        }//end of Main

    }//end of Main class
}//end of namespace


