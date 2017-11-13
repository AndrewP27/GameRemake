using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBite : TmHm
    {
        int MYIDNUMBER = 11;
        double percentChanceFlinch = .3;

        public TmHmBite()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceFlinch))
                attemptFlinch(ref defender,aForm);
        }
    }
}
