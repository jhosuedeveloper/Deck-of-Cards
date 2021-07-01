//Author: Josue Rosales
//Project Deck of Cards
//The purpose of this class is to test if the deck behaves correctly.

using Deck_of_Cardsx;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;



namespace Deck_of_Cardsx
{

    
    [TestClass]
    public class DeckTest
    {
        
        //Testing if 52 cards are populated into the deck
           [TestMethod]
        public void Test52Cards()
        {
            //Arrange
            int num_expected = 52;
            //Act

            Deck deck = new Deck();
            deck.Populate();
           
            //Assert
            Assert.AreEqual(num_expected, deck.CardCount());
        }

        //Testing that there are 51 cards on the deck after one is dealt.
        [TestMethod]
        public void Test51CardsAfterOneISDealt()
        {
            //Arrange
            int num_expected = 51;
            //Act

            Deck deck = new Deck();
            deck.Populate();
            deck.DealCard();

            //Assert
            Assert.AreEqual(num_expected, deck.CardCount());
        }

        //Testing if shuffling works and that is not exactly the same as the intialy deck after population.
        [TestMethod]
        public void CheckShuffle()
        {
            //Arrange
            Deck deck1 = new Deck();
            deck1.Populate();
            //Act

            Deck deck2 = new Deck();
            deck2.Populate();
            deck1.Shuffle();

            //Assert
            Assert.IsFalse(deck1.Compare(deck2));
        }

        //testing fail dealt when all 52 cards have been dealt already.
        [TestMethod]
        public void CheckOutOfCards()//checking error when 52 cards are dealt and deck is Empty
        {
            Deck deck = new Deck();
            deck.Populate();
            for(int i=0;i<deck.CardCount();i++)
            {
                deck.DealCard();
            }
            //there should be no cards left on deck, expecting an exception
            try
            {
                deck.DealCard();
                Assert.Fail();
            }
            catch (Exception) {}
            
        }//end of CheckOutOfCards



    }// end of UnitTest1
}//end of namespace