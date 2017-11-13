using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmHyper_Fang : TmHm
    {
        int MYIDNUMBER = 65;
        double percentChanceFlinch = .1;

        public TmHmHyper_Fang()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceFlinch))
                attemptFlinch(ref defender, aForm);
        }
    }
}
