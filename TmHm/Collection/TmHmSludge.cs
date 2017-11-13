using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSludge : TmHm
    {
        int MYIDNUMBER = 123;
        double percentChancePoison = .3;

        public TmHmSludge()
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
