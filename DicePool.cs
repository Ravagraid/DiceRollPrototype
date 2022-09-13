using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollPrototype {
    internal class DicePool : Dice {
        public Dictionary<int, int> Results;
        public int Blanks => Results[1];
        public int SingleHits => Results[4];
        public int HeavyHits => Results[5];
        public int ExplodingHits => Results[6];
        public int TotalHits => SingleHits + (HeavyHits * 2) + (ExplodingHits * 2);

        public DicePool() {
            //Initialise and populate the directory
            Results = new Dictionary<int, int>();
            for (int i = 1; i <= 6; i++) Results.Add(i, 0);
        }

        public void RollPool(int NumDice, int NumRoll) {
            for (int i = 0; i < NumDice; i++)
                for (int j = 0; j < NumRoll; j++)
                    Results[Roll()]++;
        }

        public void ExDiceRoll(int NumDice) {
            if (NumDice < 1) { return; } else {
                Results.Clear();
                for (int i = 0; i < NumDice; i++) {
                    Results[Roll()]++;
                }

            }
        }
    }
}