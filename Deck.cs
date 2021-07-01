//Author: Josue Rosales
//Project Deck of Cards
//The purpose of this class is to represent a Deck made from Cards.

using System;
using System.Collections;


namespace Deck_of_Cardsx
{
    //This class creates a deck of cards and has some functions that a deck would do
    public class Deck
    {   
        private const int DeckSize = 52;
        private const int NumSuits = 4;
        private ArrayList cards { get; set; } //creating array of object to assign cards

        //Constructor
        public Deck()
        {
            cards = null;
            cards = new ArrayList();
        }

        //Objective:    populates the deck with objects of type card
        //input:        none
        //output:       none
        public void Populate()
        {
            ArrayList list = this.cards;
            for (int i = 0; i < DeckSize / 4; i++)
            {
                for (int j = 0; j < NumSuits; j++)
                {
                    Card cardx = new Card();
                    if (j == 0)
                    {
                        cardx.Number = (i % 13) + 1;
                        cardx.Suit = "Hearts";
                    }
                    else if (j == 1)
                    {
                        cardx.Number = (i % 13) + 1;
                        cardx.Suit = "Diamonds";
                    }
                    else if (j == 2)
                    {
                        cardx.Number = (i % 13) + 1;
                        cardx.Suit = "Clubs";
                    }
                    else
                    {
                        cardx.Number = (i % 13) + 1;
                        cardx.Suit = "Spades";
                    }
                    list.Add(cardx);//adding card to list
                }//end of inner loop
            }//end of loop
        }//end of Populate function


         //Objective:    Prints all cards of deck on the console.
         //input:        none
         //output:       none
        public void PrintDeck()
        {
            ArrayList list = this.cards;
            Console.WriteLine("\n");
            foreach (Object m in list)
            {
                Console.WriteLine(((Card)m).Number.ToString() + "  " + ((Card)m).Suit);
            }
        }//end of PrintDeck Function

        //Objective:    Prints the user menu.
        //input:        none
        //output:       none
        public void PrintMenu()
        {
            ArrayList list = this.cards;
            Console.WriteLine("Menu \n" +
            "Enter 1: Print Deck Cards\n" +
            "Enter 2: Shuffle All Cards\n" +
            "Enter 3: Deal One Card\n" +
            "Enter 4: Quit");

        }//end of PrintMenu

        //Objective:    Shuffles all cards of the deck.
        //input:        none
        //output:       none
        public void Shuffle()
        {

            ArrayList list = this.cards;
            Random rndx = new Random();

            int rn;
            Card temp;
            try
            {
                if (list.Count < 1) { throw new Exception("There are no more cards on the Deck, run the pogram again to repopulate the deck"); } //in case the deck is empty throw exception
            }
            catch (Exception e) { Console.WriteLine(e + " ..Quitting Game\n"); System.Environment.Exit(0); }
            for (int i = 0; i < list.Count; i++)
            {
                temp = new Card();
                rn = rndx.Next(DeckSize - (DeckSize - list.Count));//to avoid index out of bounds, it will fix itself

                temp.Number = ((Card)list[rn]).Number; //swapping.
                temp.Suit = ((Card)list[rn]).Suit; //swapping.
                list[rn] = list[i];
                list[i] = temp;

            }//end of loop


            Console.WriteLine("...Shuffling Successful!");

        }//end of shuffle function



        //Objective:    Starts the whole game.
        //input:        none
        //output:       none
        public void StartGame()
        {
            ArrayList list = this.cards;
            this.Populate(); //populating the list with 52 cards
            int answer = 0;
            while (answer != 4)
            {
                answer=this.GetValidAnswer();
                //option1 print Deck Cards:
                if (answer == 1)
                {
                    PrintDeck();
                }
                else if (answer == 2)//option2 Shuffle All Cards:
                {
                    Shuffle();
                }
                else if (answer == 3)//option3 Deal One Card:
                {
                    DealCard();
                }
                else
                {
                    Console.WriteLine("Quitting Game\n");
                    System.Environment.Exit(0);
                }

            }//end of outer loop exit game

            Console.WriteLine("Exiting Game .....");
        }

        //Objective:    It prints one card from the deck.
        //input:        none
        //output:       none
        public void DealCard()
        {
            ArrayList list = cards;
            if (list.Count != 0)
            {
                Console.WriteLine(((Card)list[list.Count - 1]).Number.ToString() + "  " + ((Card)list[list.Count - 1]).Suit);
                list.RemoveAt(list.Count - 1);
            }
            else
            {
                Console.WriteLine("There are no More Cards on the Deck, run the program again!");
                //break;
            }
        }

        //Objective:    To return the number of cards on teh Deck.
        //input:        none
        //output:       Number of Cards
        public int CardCount()
        {
            return cards.Count;
        }

        //Objective:    Compares if two decks are the same.
        //input:        Object of type deck
        //output:       true if the sequence of decks match the other deck, otherwise false.
        public bool Compare(Deck deck)
        {
            int countSame = 0;
            for(int i=0;i<deck.CardCount();i++)
            {

                if((( (Card)this.cards[i]).Number == ((Card)deck.cards[i]).Number) && (((Card)this.cards[i]).Suit.Equals( ((Card)deck.cards[i]).Suit)))
                {
                    countSame++;
                }
            }
            return (countSame==DeckSize);
        }//end of Compare

        //Objective:    To get Valid answer from user only numbers and withiin range.
        //input:        none
        //output:       valid num
        public int GetValidAnswer()
        {
            this.PrintMenu();
            String input = Console.ReadLine();
            bool InvalidNumber = true;
            int answer = 0;
          

            while (InvalidNumber)
            {
                try
                {
                    answer = Int32.Parse(input);
                    if(answer < 1 || answer > 4 )
                    {
                        throw new Exception();
                    }
                   
                    InvalidNumber = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Answer, Try again from Options 1-4");
                    this.PrintMenu();
                    input = Console.ReadLine();
                }
            }//end of while loop
            return answer;
        }


    } // end of class
}//end of namespace
