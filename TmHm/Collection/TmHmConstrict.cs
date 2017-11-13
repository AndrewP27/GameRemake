using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmConstrict : TmHm
    {
        int MYIDNUMBER = 22;
        double percentChanceLowSpd = .1;
        int DELTASPEED = -1;

        public TmHmConstrict()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceLowSpd))
                changeSpeed(DELTASPEED, ref defender, aForm);
        }
    }
}
