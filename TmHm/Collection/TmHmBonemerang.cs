using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBonemerang : TmHm
    {
        double myAcc = 0.9;
        int MYIDNUMBER = 15;
        int HITNUM = 2;

        public TmHmBonemerang()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {

            if (defender.isAlive() && getRemainingPP() > 0 && attacker.canAttack(ref attacker, aForm))
            {
                decrementPP();
                useMove(ref attacker, ref defender, aForm);
            }
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {

            for (int i = 0; i < HITNUM; i++)
            {
                if (checkHit(ref attacker, ref defender, myAcc))
                    applyDamage(ref attacker, ref defender, aForm);
                else
                    aForm.setTextMessage(attacker.getName() + " has missed!");
                if (!defender.isAlive())
                    break;
            }

        }
    }
}
