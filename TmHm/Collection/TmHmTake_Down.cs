﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmTake_Down : TmHm
    {
        int MYIDNUMBER = 146;

        public TmHmTake_Down()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            double defenderHPLeft = defender.getHP();

            double damageHit = applyDamage(ref attacker, ref defender, aForm);

            if (defenderHPLeft < damageHit)
                attacker.damagePkm(defenderHPLeft * .33, this, aForm, ref attacker);
            else
                attacker.damagePkm(damageHit * .33, this, aForm, ref attacker);

            aForm.setSelfDamageMessage(attacker.getName(), "Recoil", attacker.getTrainerSlot());


        }
    }
}
