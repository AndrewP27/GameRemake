using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSmog : TmHm
    {
        int MYIDNUMBER = 124;
        double percentChancePoison = .4;

        public TmHmSmog()
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
