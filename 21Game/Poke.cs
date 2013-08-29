using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21Game
{
    class Poke
    {
        private int faceValue;
        private string Variety;
     
        public Poke(int i)
        {
            faceValue = i % 13;
            if (i % 13 == 0 && i > 0 && i < 53)
                faceValue = 13;


            switch ((i-1) / 13)
            {
                case 0:
                    Variety = "Heart";
                    break;
                case 1:
                    Variety = "Spade";
                    break;
                case 2:
                    Variety = "Diamond";
                    break;
                case 3:
                    Variety = "Club";
                    break;
                default:
                    Variety = null;
                    break;
            }

            if (i <= 0 || i >= 53)
                Variety = "Invalid";
 
        }

        public string getVariety()
        {
            return Variety;
        }
        public int getFaceValue()
        {
            return faceValue;
        }
        public int getCardNumber()
        {
            switch (Variety)
            {
                case "Heart":
                    return faceValue;
                case "Spade":
                    return 13 + faceValue;
                case "Diamond":
                    return 26 + faceValue;
                case "Club":
                    return 39 + faceValue;
                default:
                    return 0;
            }
        }


    }
}
