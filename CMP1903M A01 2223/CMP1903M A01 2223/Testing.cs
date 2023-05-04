using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMP1903M_A01_2223
{
    public class PackTests
    {
        private static void showCard(Card card)
        {
            Console.WriteLine(String.Format("--Card--\nSuit: {0}, Value: {1}", card.Suit, card.Value));
        }
        public static void showPack()
        {
           for(int i = 0; i < Pack.getCardCount(); i++)
            {
                showCard(Pack.peekCardAt(i));
            }
        }

        public static void testFisherYates()
        {
            Pack initPack = new Pack();
            // show the pack initally ordered
            showPack();

            Console.WriteLine("--AFTER-SHUFFLE--");
            // shuffle the pack using the Fisher-Yates method
            Pack.shuffleCardPack(1);
            showPack();     // show the pack after shuffling
        } 

        public static void testRiffle()
        {
            Pack initPack = new Pack();
            // show the pack initally ordered
            showPack();

            Console.WriteLine("--AFTER-SHUFFLE--");
            // shuffle the pack using the Riffle method
            Pack.shuffleCardPack(2);
            showPack();
        }

        public static void testDeal()
        {
            Pack initPack = new Pack();

            showPack();
            Card dealt = Pack.deal();

            Console.WriteLine("Dealt Card:");
            showCard(dealt);

            Console.WriteLine("--AFTER-DEALING--");
            showPack();     // show pack after dealing
        }


        public static void testDealCard(int numCards)
        {
            Pack initPack = new Pack();

            showPack();   // show the pack initally
            List<Card> cards = Pack.dealCard(numCards);
            
            Console.WriteLine("Dealt Cards:");
            for(int i = 0; i < cards.Count; i++)
            {
                showCard(cards[i]);
            }

            Console.WriteLine("--AFTER-DEALING--");
            showPack();     // show the pack after dealing
        }



        /* Testing the exception clauses */
        public static void testDealEmptyPackRaisesException()
        {
            Pack initPack = new Pack();
            try
            {
                int initCount = Pack.getCardCount();
                for(int i = 0; i <= initCount + 1; i++)  // attempt deal more cards than we actually have 
                {
                    Pack.deal();
                }
            }catch(InvalidOperationException e)
            {
                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception was raised.");
        }


        public static void testDealCardInvalidCountRaisesException()
        {
            bool thrown = false;
            Pack initPack = new Pack();

            try
            {
                List<Card> myCards = Pack.dealCard(Pack.getCardCount() + 1);   // attempt to deal more cards than we actually have
            }catch(ArgumentOutOfRangeException e)
            {
                thrown = true;
                Console.WriteLine("Exception raised as expected:" + e.ToString());
            }

            if (!thrown)
                Console.WriteLine("No suitable exception raied (Dealing cards over count).");
            
            try
            {
                List<Card> myCards = Pack.dealCard(-1);
            }catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception raied (Dealing -1 cards).");
        }


        public static void testShuffleUnitialisedPackRaisesException()
        {
            // assuming pack has not yet been initalised.
            try
            {
                Pack.shuffleCardPack(0);
            }catch(InvalidOperationException e)
            {
                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception was raised.");
        }

        public static void testDealUnitialisedPackRaisesException()
        {
            // assuming pack has not yet been initialised.
            try
            {
                Pack.deal();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception was raised.");
        }

        public static void testDealCardUnitialisedPackRaisesException()
        {
            // assuming pack has not yet been initialised.
            try
            {
                Pack.dealCard(2);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception was raised.");
        }

        public static void testGetCardCountUnitialisedPackRaisesException()
        {
            // assuming pack has not yet been initialised.
            try
            {
                int count = Pack.getCardCount();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception was raised.");
        }

        public static void testRestPackUnitialisedPackRaisesException()
        {
            // assuming pack has not yet been initialised.
            try
            {
                Pack.resetPack();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception raised as expected:" + e.ToString());
                return;
            }

            Console.WriteLine("No suitable exception was raised.");
        }
    }
}
