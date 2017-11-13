using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFlash : TmHm
    {
        int MYIDNUMBER = 46;
        int deltaAcc = -1;

        public TmHmFlash()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAcc(deltaAcc, ref defender, aForm);

        }
    }
}
