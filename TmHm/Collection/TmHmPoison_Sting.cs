using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPoison_Sting : TmHm
    {
        int MYIDNUMBER = 95;
        double percentChancePoison = .3;

        public TmHmPoison_Sting()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChancePoison))
                attemptPoison(ref defender, aForm);
        }
    }
}
