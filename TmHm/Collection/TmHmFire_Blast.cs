﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFire_Blast : TmHm
    {
        int MYIDNUMBER = 42;
        double CHANCE_OF_BURN = 0.1;

        public TmHmFire_Blast()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
            if (checkProb(CHANCE_OF_BURN))
                attemptBurn(ref defender, aForm);
        }
    }
}
