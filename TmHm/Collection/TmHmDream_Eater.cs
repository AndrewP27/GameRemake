using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDream_Eater : TmHm
    {
        int MYIDNUMBER = 36;

        public TmHmDream_Eater()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (defender.isAsleep())
            {
                double defenderHPLeft = defender.getHP();

                double damageHit = applyDamage(ref attacker, ref defender, aForm);

                if (defenderHPLeft < damageHit)
                    heal(ref attacker, defenderHPLeft * .5, aForm);
                else
                    heal(ref attacker, damageHit * .5, aForm);
            }
            else
                aForm.setTextMessage(defender.getName() + " is not Asleep");
        }
    }
}
