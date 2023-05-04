using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    { 
        private int value;
        private int suit;
        public Card(int value, int suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public int Value 
        {
            get { return this.value; }
            
            // setter that validates card value input
            set
            {
                if (value < 1 || value > 13)
                    throw new ArgumentOutOfRangeException("Card values must be between 1-13 inclusive.");
                this.value = value;
            }
        }
        public int Suit 
        {
            get { return this.suit; }
            
            // setter that validates card suit input
            set
            {
                if (value < 1 || value > 4)
                    throw new ArgumentOutOfRangeException("Suit values must be between 1-4 inclusive.");
                this.suit = value;
            }
        }
    }
}
