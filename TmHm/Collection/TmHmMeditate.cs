using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmMeditate : TmHm
    {
        int MYIDNUMBER = 79;
        int deltaAtk = 1;

        public TmHmMeditate()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAtk(deltaAtk, ref attacker, aForm, false);

        }
    }
}
