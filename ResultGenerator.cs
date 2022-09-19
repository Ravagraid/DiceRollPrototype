/*Special Rules to account for:
 * Sustained (Reroll a particular dice result) - done
 * Homing (Reroll Blanks)
 * Fusillade (Reroll Counters and Heavy Counters)
 * Sustained + Homing (Reroll particular dice result + Reroll Blanks)
 * Devastating (Exploding Hits count as 3 instead of 2
 * 
 * Normal result vs Obscured (No Exploding Hits)
 * Fusillade vs Obscured (Reoll C + HC, No Ex)
 * Homing Vs Obscured (Reroll Blanks, No Ex)
 * Sustained Vs Obscured (Reroll a result, No Ex)
 * Devastating Vs Obscured (Ex count as 3, No extra)
 * 
 * Normal Vs Interphase (HH count as 1, no Ex)
 * Fusillade Vs Interphase (Reroll C + HC, HH count as 1, No Ex)
 * Sustained Vs Interphase (Reroll 1 result, HH count as 1, No Ex)
 * Homing Vs Interphase (Reroll Blanks, HH count as 1, No Ex)
 * Sustained + Homing Vs Interphase (Reroll blanks + 1 result, HH count as 1, No Ex)
 * Devastating Vs Interphase (ExH Count as 3, HH count as 1, No Ex)
*/

namespace DiceRollPrototype {
    internal class ResultGenerator : DicePool {
        Dictionary<int,int> OGResult, RerollResult;
        string[] ResultName = new string[] {"Blanks", "Counters", "Heavy Counters",
                                            "Hits", "Heavy Hits", "Exploding Hits" };

        internal ResultGenerator() {
            OGResult = new Dictionary<int,int>(Results);
            RerollResult = new Dictionary<int,int>();
        }
        internal void ModifierChecker(string modifier) {
            // 1 = homing, 2 = sustained
            int mod = 0;
            switch (modifier) {
                case "Normal":
                    ShowResult();
                    break;
                case "Sustained":
                case "sustained":
                case "sustain":
                case "Sustain":
                    SingleResultReroll(mod = 2);
                    break;
            }
        }
        internal void ShowResult() {
            //Loop through Dictionary to display results
            Console.WriteLine("\nResults from dice pool");
            foreach (var item in Results) {
                Console.WriteLine($"{ResultName[item.Key - 1] + ":",-18}{item.Value}");
                //Loop through Exploding Dictionary for Ex Results
                if (item.Key == 6) {
                    Console.WriteLine("\nResults from Exploding Hits.");
                    for (int i = 0; i < 3; i++) {
                        Console.WriteLine($"{ResultName[i + 3] + ":",-18}{ExResults[i + 4]}");
                    }
                    //Display Total Hits
                    Console.WriteLine($"\nTotal Hits: {TotalHits,7}");
                }
            }
        }

        internal void SingleResultReroll(int i){
            if (i == 2) {
                foreach (var item in Results) {
                    if (item.Value == Results.Values.Max() && item.Key <= 3) {
                        ReRollPool(item.Value,4,RerollResult);
                    }
                }
            } else if (i == 1) {

            }
        }
    }
}