using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmAgility : TmHm
    {
        int MYIDNUMBER = 4;
        int DELTASPD = 2;

        public TmHmAgility()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeSpeed(DELTASPD, ref attacker, aForm, false);
        }
    }
}
