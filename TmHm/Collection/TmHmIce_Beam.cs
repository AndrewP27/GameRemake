using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmIce_Beam : TmHm 
    {
        int MYIDNUMBER = 67;
        double percentChanceFreeze = .1;

        public TmHmIce_Beam()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceFreeze))
                attemptFreeze(ref defender, aForm);
        }
    }
}
