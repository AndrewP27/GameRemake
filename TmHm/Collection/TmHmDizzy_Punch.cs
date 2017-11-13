using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDizzy_Punch : TmHm
    {
        int MYIDNUMBER = 30;
        double percentChanceConfuse = .2;

        public TmHmDizzy_Punch()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceConfuse))
                attemptConfuse(ref defender, aForm);
        }
    }
}
