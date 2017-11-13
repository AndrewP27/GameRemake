using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSoft_Boiled : TmHm
    {
        int MYIDNUMBER = 126;

        public TmHmSoft_Boiled()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            heal(ref attacker, attacker.getMaxHP() * .5, aForm);
        }
    }
}
