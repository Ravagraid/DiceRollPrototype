namespace DiceRollPrototype {
    internal class DicePool : Dice {
        public Dictionary<int,int> Results;
        public Dictionary<int,int> ExResults;
        public int Blanks => Results[1];
        public int Counters => Results[2];
        public int HeavyCounters => Results[3];
        public int SingleHits => Results[4] + ExResults[4];
        public int HeavyHits => Results[5] + ExResults[5];
        public int ExplodingHits => Results[6] + ExResults[6];
        public int TotalHits => SingleHits + (HeavyHits * 2) + (ExplodingHits * 2);

        public DicePool() {
            //Initialise and populate the directory
            Results = new Dictionary<int,int>();
            ExResults = new Dictionary<int,int>();
            for (int i = 1; i <= 6; i++) {
                Results.Add(i,0);
                ExResults.Add(i,0);
            }
        }

        //Roll the number of dice a number of times, adding each result to Dictionary
        public void RollPool(int NumDice,int NumRoll) {
            for (int i = 0; i < NumDice; i++) {
                for (int j = 0; j < NumRoll; j++) {
                    Results[Roll()]++;
                }
            }
            ExDiceRoll(Results[6]);
        }

        //Attempt at Exploding Dice. Probably wrong.
        //Copy of dice rolling function without extra for loop.
        public void ExDiceRoll(int NumDice) {
            if (NumDice == 0) { return; } else {
                for (int i = 0; i < NumDice; i++) {
                    int temp = Roll();
                    Results[temp]++;
                    ExResults[temp]++;
                }
            }
        }
    }
}