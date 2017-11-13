using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmLeech_Life : TmHm
    {
        int MYIDNUMBER = 72;

        public TmHmLeech_Life()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            useMoveAbsorb(ref attacker, ref defender, aForm);
        }
    }
}
