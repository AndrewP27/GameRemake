using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBody_Slam : TmHm
    {
        int MYIDNUMBER = 13;
        double percentChanceParalyze = .3;

        public TmHmBody_Slam()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceParalyze))
                attemptParalyze(ref defender, aForm);
        }
    }
}
