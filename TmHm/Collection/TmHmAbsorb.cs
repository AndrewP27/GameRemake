using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmAbsorb : TmHm
    {
        int MYIDNUMBER = 1;

        public TmHmAbsorb()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            useMoveAbsorb(ref attacker, ref defender, aForm);
        }
    }
}
