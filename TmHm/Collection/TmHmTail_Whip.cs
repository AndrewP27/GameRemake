﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmTail_Whip : TmHm
    {
        int MYIDNUMBER = 145;
        int DELTADEF = -1;

        public TmHmTail_Whip()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(DELTADEF, ref defender, aForm);
        }
    }
}
