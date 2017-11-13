using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmConfusion : TmHm
    {
        int MYIDNUMBER = 21;
        double percentChanceConf = .1;

        public TmHmConfusion()
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
