using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmThunder : TmHm
    {
        int MYIDNUMBER = 149;
        double percentChanceParalyze = 0.3;

        public TmHmThunder()
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
