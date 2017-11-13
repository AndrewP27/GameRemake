using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBone_Club : TmHm
    {
        int MYIDNUMBER = 14;
        double percentChanceFlinch = .1;

        public TmHmBone_Club()
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
