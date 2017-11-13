using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmWaterfall : TmHm
    {
        int MYIDNUMBER = 161;
        double percentChanceFlinch = .2;

        public TmHmWaterfall()
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
