using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmTwineedle : TmHm
    {
        double myAcc = 1;
        int MYIDNUMBER = 157;
        int HITNUM = 2;
        double percentChancePoison = 0.2;

        public TmHmTwineedle()
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
                {
                    applyDamage(ref attacker, ref defender, aForm);
                }
                else
                    aForm.setTextMessage(attacker.getName() + " has missed!");

                if (!defender.isAlive())
                    break;
            }
            
            if (checkProb(percentChancePoison))
                attemptPoison(ref defender, aForm);
        }
    }
}
