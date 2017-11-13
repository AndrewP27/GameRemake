using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmThunder_Shock : TmHm
    {
        int MYIDNUMBER = 152;
        double percentChanceParalyze = 0.1;

        public TmHmThunder_Shock()
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
