using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPsybeam : TmHm
    {
        int MYIDNUMBER = 97;
        double percentChanceConf = .1;

        public TmHmPsybeam()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceConf))
                attemptConfuse(ref defender, aForm);
        }
    }
}
