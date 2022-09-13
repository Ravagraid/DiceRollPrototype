using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollPrototype {
    internal class DicePool : Dice {
        public Dictionary<int, int> Results;

        public int SingleHits => Results[4];
        public int HeavyHits => Results[5] * 2;
        public int ExplodingHits => Results[6] * 2;

        public DicePool() {
            Results = new Dictionary<int, int>();
            //initialise the dictionary
            for (int i = 1; i <= 6; i++) Results.Add(i, 0);
        }

        public void RollPool(int NumDice, int NumRoll) {
            for (int i = 0; i < NumDice; i++)
                for (int j = 0; j < NumRoll; j++)
                    Results[Roll()]++;
        }

    }
}