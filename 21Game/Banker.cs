using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21Game
{
    class Banker
    {
        private List<Poke> card = new List<Poke>();
        private int cardTotal;
        private int card_ace_for_eleven;

        public Banker()
        {
            cardTotal = 0;
            card_ace_for_eleven = 0;
        }

        public void drawCard(Poke draw)
        {
            card.Add(draw);
            int ValueOfCard;

            if (draw.getFaceValue() > 10)
                ValueOfCard = 10;
            else
                ValueOfCard = draw.getFaceValue();

            if (ValueOfCard == 1)
            {
                if (cardTotal <= 10)
                {
                    cardTotal += 11;
                    card_ace_for_eleven++;
                }
                else
                    cardTotal += 1;
                    
            }
            else
            {
                if ((cardTotal + ValueOfCard) > 21 && card_ace_for_eleven > 0)
                {
                    cardTotal = cardTotal + ValueOfCard - 10;
                    card_ace_for_eleven--;
                }
                else if ((cardTotal + ValueOfCard) > 21 && card_ace_for_eleven == 0)
                    cardTotal = cardTotal + ValueOfCard;
                else if ((cardTotal + ValueOfCard) <= 21)
                    cardTotal = cardTotal + ValueOfCard;
            }

        }

        public Boolean isBlackJack()
        {
            return (card.Count == 2 && cardTotal == 21);
        }

        public Boolean isBurst()
        {
            return (cardTotal > 21);
        }

        public Boolean needDrawCard()
        {
            if (cardTotal >= 17)
                return false;
            else
                return true;
        }

        public int getCardTotal()
        {
            return cardTotal;
        }

        public void clearCard()
        {
            card.Clear();
            cardTotal = 0;
            card_ace_for_eleven = 0;
        }

        public List<int> cardNumbers()
        {
            List<int> ret = new List<int>();
            foreach (Poke poke in card)
            {
                ret.Add(poke.getCardNumber());
            }
            return ret;
        }

    }
}
