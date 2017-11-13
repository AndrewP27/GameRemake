using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSmokescreen : TmHm
    {
        int MYIDNUMBER = 125;
        int DELTAACC = -1;

        public TmHmSmokescreen()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAcc(DELTAACC, ref defender, aForm);
        }
    }
}
