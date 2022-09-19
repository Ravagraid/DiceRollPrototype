namespace DiceRollPrototype {
    internal class DicePool {
        internal Dictionary<int,int> Results, ExResults;
        internal int Blanks => Results[1];
        internal int Counters => Results[2];
        internal int HeavyCounters => Results[3];
        internal int SingleHits => Results[4] + ExResults[4];
        internal int HeavyHits => Results[5] + ExResults[5];
        internal int ExplodingHits => Results[6] + ExResults[6];
        internal int TotalHits => SingleHits + (HeavyHits * 2) + (ExplodingHits * 2);
        private Random r;
        public DicePool() {
            r = new Random();
            //Initialise and populate the directory
            Results = new Dictionary<int,int>();
            ExResults = new Dictionary<int,int>();
            for (int i = 1; i <= 6; i++) {
                Results.Add(i,0);
                ExResults.Add(i,0);
            }
        }

        private int Roll() {
            return r.Next(1,7);
        }

        //Roll the number of dice a number of times, adding each result to Dictionary
        public void ReRollPool(int NumDice,int NumRoll) {
            for (int i = 0; i < NumDice; i++) {
                for (int j = 0; j < NumRoll; j++) {
                    ExResults[Roll()]++;
                }
            }
        }
        //For modifier use, to store the result for display
        public void ReRollPool(int NumDice, int NumRoll, Dictionary<int,int> dict) {
            for (int i = 0; i < NumDice; i++) {
                for (int j = 0; j < NumRoll; j++) {
                    ExResults[Roll()]++;
                    dict[Roll()]++;
                }
            }
        }

        //Attempt at Exploding Dice. Probably wrong.
        //Copy of dice rolling function without extra for loop.
        internal void RollPool(int NumDice) {
            if (NumDice == 0) { return; } else {
                for (int i = 0; i < NumDice; i++) {
                    Results[Roll()]++;
                }
            }
            ReRollPool(Results[6],4);
        }
    }
}