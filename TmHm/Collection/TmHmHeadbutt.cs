using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmHeadbutt : TmHm
    {
        int MYIDNUMBER = 59;
        double percentChanceFlinch = .3;

        public TmHmHeadbutt()
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
