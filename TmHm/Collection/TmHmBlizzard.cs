using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBlizzard : TmHm
    {
        int MYIDNUMBER = 12;
        double percentChanceFreeze = .1;

        public TmHmBlizzard()
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
