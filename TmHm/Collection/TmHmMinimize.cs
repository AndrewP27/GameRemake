using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmMinimize : TmHm
    {
        int MYIDNUMBER = 85;
        int DeltaEva = 2;

        public TmHmMinimize()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeEva(DeltaEva, ref defender, aForm, false);
            defender.minimize();
        }
    }
}
