namespace DiceRolePrototype {
    public class DiceRoller {
        int[] SpecRules = new int[] {
            1, // Normal
            2, // Homing / Sustained
            3, // Fusillade / Sustained + Homing
            4, // Devastating
            5, // Shroud
            6, // Obscured
        };
        private List<float> DiceList = new();

        public float Roll(int DiceNum, int specrule) {
            Random rand = new();
            Dictionary<int, int> Dice = new();

            float HitStore = 0;
            int ind = 0;
            //initialise the Dictionary with 6 keys
            Dice.Clear();
            for (int i = 1; i <= 6; i++)
                Dice.Add(i, 0);

            //Loop through every die in the pool
            for (int i = 0; i < DiceNum; i++) {
                //Roll each die in the pool 1 million times
                for (int j = 0; j < 1000000; j++) {
                    //rolls random number to simulate a die
                    int diceroll = rand.Next(1, 7);
                    Dice[diceroll]++;
                }
            }

            //loop through each key in dictionary
            for (int i = 0; i <= Dice.Count; i++) {
                switch (i) {
                    case 1:
                        if (specrule == 2  || specrule == 3) {
                            AllHits(i, RoundNumber(Dice, i));
                        }
                        break;
                    case 2:
                        if (specrule == 3) {
                            AllHits(i, RoundNumber(Dice, i));
                        }
                        break;
                    case 3: 
                        break;
                    case 4:
                        AllHits(i, RoundNumber(Dice, i));
                        break;
                    case 5:
                        AllHits(i, RoundNumber(Dice, i));
                        break;
                    case 6:
                        AllHits(i, RoundNumber(Dice, i));
                        break;
                }
            }
            //Adds all hits/heavy hits/exploding hits into a single variable
            foreach (var item in DiceList) {
                HitStore += DiceList[ind];
                ind++;
            }
            DiceList.Clear();
            return HitStore;
        }

        private void AllHits(int i, float HitNum) {
            //if key is a heavy hit/exploding, double result
            if (i >= 5) { HitNum += HitNum; }
            //if key is exploding hit, call ExDice method  
            if (i == 6) { ReRolls(10, HitNum); }
            DiceList.Add(HitNum);
        }

        // Exploding Dice with depth variable
        private void ReRolls(int depth, float HitNum) {
            float ReDice = 0;
            //loop to interate equal to depth
            for (int i = 0; i < depth; i++) {
                //Check to ensure first loop takes initial 6's
                //else statement to take results generated from initial 6's
                if (i == 0) {
                    ReDice = (HitNum / 6) / 2;
                } else {
                    ReDice /= 6;
                }
                //inserts results into correct position in list, with heavy/explodings being doubled
                DiceList.Insert(0, ReDice);
                DiceList.Insert(1, ReDice * 2);
                DiceList.Insert(2, ReDice * 2);
            }
        }

        private static float RoundNumber(Dictionary<int, int> dic, int i) {
            //convert result into float
            float temp = dic.GetValueOrDefault(i) / (float)10000000;
            float hitnum = (float)Math.Round((float)temp * 10, 6);
            return hitnum;
        }
    }
}