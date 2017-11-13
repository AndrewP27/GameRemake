using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmRecover : TmHm
    {
        int MYIDNUMBER = 104;

        public TmHmRecover()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            heal(ref attacker, attacker.getMaxHP()*.5, aForm);
        }
    }
}
