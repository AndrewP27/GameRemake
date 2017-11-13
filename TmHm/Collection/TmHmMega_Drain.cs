using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmMega_Drain : TmHm
    {
        int MYIDNUMBER = 80;

        public TmHmMega_Drain()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            useMoveAbsorb(ref attacker, ref defender, aForm);
        }
    }
}
