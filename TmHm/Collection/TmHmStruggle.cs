using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmStruggle : TmHm
    {
        int MYIDNUMBER = 135;

        public TmHmStruggle()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            double defenderHPLeft = defender.getHP();

            double damageHit = applyDamage(ref attacker, ref defender, aForm);

            aForm.setTextMessage(attacker.getName() + " was hurt by the recoil!");
            attacker.damagePkm(damageHit * .5, this, aForm, ref attacker);
            aForm.setSelfDamageMessage(attacker.getName(), getName(), attacker.getTrainerSlot());
        }
    }
}
