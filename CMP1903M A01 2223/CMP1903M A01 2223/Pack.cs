using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        protected static List<Card> pack;

        public Pack()
        {
            pack = new List<Card>();
            resetPack();
        }

        public static void resetPack() // Additional method
        {
            if (pack == null)
                throw new InvalidOperationException("Cannot reset uninitialised pack.");

            pack.Clear();
            for (int suit = 1; suit <= 4; suit++)   // for each type of suit
            {
                for (int value = 1; value < 13; value++)  // for each value within a suit
                {
                    pack.Add(new Card(value, suit));    // instantiate a new card with each suit-value combination
                }
            }
        }

        public static int getCardCount()    // return the number of cards within the pack
        {
            if(pack == null)
                throw new InvalidOperationException("Pack is unitialised.");
            return pack.Count; 
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            if (pack == null)
                throw new InvalidOperationException("Cannot shuffle uninitialised pack.");

            Random rand = new Random();
            switch (typeOfShuffle)
            {
                case 1:
                    return fisherYatesShuffle(rand);
                case 2:
                    return riffleShuffle(rand);
                case 3:
                    return true;
            }

            return false;
        }

        public static Card peekCardAt(int position)  // get card at speicifed index (Additional method)
        {
            if (position < 0 || position >= pack.Count)
                throw new ArgumentOutOfRangeException(String.Format("Cannot retrieve card at position {0} from pack of size {1}.", 
                    position, pack.Count));

            return pack[position];
        }

        /* Fisher-Yates shuffle implementation (additional method) */
        protected static bool fisherYatesShuffle(Random rand)
        {
            if (pack.Count < 2)
            {
                return false;   // no shuffling would take place
            }

            for(int i = 0; i < Pack.pack.Count - 1; i++)
            {
                int randIndex = rand.Next(0, pack.Count);
                Card temp = pack[randIndex];
                
                // exchange the randomly selected card for the card at i
                pack[randIndex] = pack[i];
                pack[i] = temp;
            }

            return true;
        }

        /* Riffle shuffle implementation (additional method)*/
        protected static bool riffleShuffle(Random rand)
        {
            if(pack.Count < 2) 
            {
                return false;   // no shuffling would take place
            }

            int halfPoint = pack.Count / 2;     // assuming the pack is perfectly split
            List<Card> newList = new List<Card>(pack);

            List<Card> left = new List<Card>(newList.Take(halfPoint));  // take the bottom half of the pack
            List<Card> right = new List<Card>(newList.Skip(halfPoint)); // take the top half of the pack

            newList.Clear();
            while (left.Count > 0 && right.Count > 0)   // while there are still cards to be added
            {
                if(rand.Next(0, 2) == 0)   // randomly select either the left or right pile to take from
                {
                    newList.Add(right.First());
                    right.RemoveAt(0);
                }
                else
                {
                    newList.Add(left.First());
                    left.RemoveAt(0);
                }
            }

            // ensure all cards are added from whichever pile did not run out of cards
            newList.AddRange(left);
            newList.AddRange(right);
            pack = newList;    // assign the new list to our pack

            return true;
        }

        public static Card deal()
        {
            if (pack == null || pack.Count == 0)    // ensure we have a vaid pack to deal from
                throw new InvalidOperationException("Cannot deal card from empty pack");

            Card topItem = pack.Last();
            pack.RemoveAt(pack.Count - 1);

            return topItem;
        }

        public static List<Card> dealCard(int amount)
        { 
            // ensure the pack exists and there are enough cards to remove
            if (pack == null)
                throw new InvalidOperationException("Cannot deal from uninitialised pack.");

            if (pack.Count < amount)
                throw new ArgumentOutOfRangeException(String.Format("Cannot remove {0} cards from pack of size {1}.", amount, pack.Count));

            // remove and return 'amount' of cards from the top of the pack
            List<Card> output = new List<Card>(pack.Skip(pack.Count - amount).Take(amount));
            pack.RemoveRange(pack.Count - amount, amount);

            return output;
        }
    }
}
