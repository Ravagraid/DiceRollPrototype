using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollPrototype {
    internal class Dice {
        private Random r;

        protected Dice() {
            r = new Random();
        }

        protected int Roll() {
            return r.Next(1, 7);
        }   
    }
}