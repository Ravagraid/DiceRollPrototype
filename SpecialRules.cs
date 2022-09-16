/*Special Rules to account for:
 * Sustained (Reroll a particular dice result)
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
    internal class SpecialRules {
        internal SpecialRules() { }

        internal int Sustained(Dictionary<int,int> results) {
            var keyOfMaxValue = results.Aggregate((x,y) => x.Value > y.Value ? x : y).Key;
            return keyOfMaxValue;
        }
    }
}