using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFocus_Energy : TmHm
    {
        int MYIDNUMBER = 49;
        int CHANGE_CRIT = 1;

        public TmHmFocus_Energy()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeCrit(CHANGE_CRIT, ref attacker, aForm, false);
        }
    }
}
