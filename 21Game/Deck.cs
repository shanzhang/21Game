using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21Game
{
    class Deck
    {
        private List<Poke> deck = new List<Poke>();

        public Deck()
        {
            deck.Clear();
            for (int i = 0; i < 52; i++)
            {
                Poke temp = new Poke(i + 1);
                deck.Add(temp);
            }
            
        }

        public int getCardRemain()
        {
            return deck.Count;
        }

        public Poke drawCard()
        {
            if (getCardRemain()==0)
                return null;

            Random ro = new Random();
            int random=ro.Next(1,getCardRemain());
            
            Poke tmp = deck[random];
            deck.RemoveAt(random);

            return tmp;
        }

        public void initializeCard()
        {
            deck.Clear();
            for (int i = 0; i < 52; i++)
            {
                Poke temp = new Poke(i + 1);
                deck.Add(temp);
            }
        }
        
    }
}
