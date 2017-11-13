using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBide : TmHm
    {
        int MYIDNUMBER = 9;
        int useNum;
        double storedDamage;

        public TmHmBide()
        {
            SetUpInit(MYIDNUMBER);
            useNum = 0;
            storedDamage = 0;
        }

        public override void onDamage(double damage, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {
            if(useNum > 0)
            storedDamage += damage;
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (useNum == 0)
            {
                decrementPP();
                storedDamage = 0;
                attacker.setPersistantMove(this);
                aForm.setTextMessage(attacker.getName() + " begins to store energy!");
            }

            if (useNum > 1)
            {
                if (attacker.isConfused())
                    aForm.setTextMessage(attacker.getName() + " is Confused!");

                if (!attacker.canAttack(ref attacker, aForm))
                {
                    useNum = 0;
                    attacker.setPersistantMove(null);
                    return;
                }

                aForm.setTextMessage(attacker.getName() + " used " + getName());

                if (!checkHit(ref attacker, ref defender))
                {
                    aForm.setTextMessage(attacker.getName() + " has missed!");
                    useNum = 0;
                    attacker.setPersistantMove(null);
                    return;
                }

                if (Utilities.Effectiveness(defender.getPkmType1(), getType()) == 0)
                {
                    aForm.setTextMessage(defender.getName() + " is not effected!");
                    useNum = 0;
                    attacker.setPersistantMove(null);
                    return;
                }

                if (defender.isAlive() && getRemainingPP() > 0 && attacker.canAttack(ref attacker, aForm))
                {
                    useNum = 0;
                    attacker.setPersistantMove(null);
                    useMove(ref attacker, ref defender, aForm);
                    return;
                }
            }

            useNum++;
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm, 2 * storedDamage);
        }
        
    }
}
