using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBubble : TmHm
    {
        int MYIDNUMBER = 16;
        double percentChanceLowerSpeed = .1;
        int DELTASPEED = -1;

        public TmHmBubble()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceLowerSpeed))
                changeSpeed(DELTASPEED, ref defender, aForm);
        }
    }
}
