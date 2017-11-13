using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDouble_Team : TmHm
    {
        int MYIDNUMBER = 33;
        int DELTAEVA = 1;

        public TmHmDouble_Team()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeEva(DELTAEVA, ref attacker, aForm, false);
        }
    }
}
