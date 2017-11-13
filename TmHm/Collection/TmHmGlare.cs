using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmGlare : TmHm
    {
        int MYIDNUMBER = 52;

        public TmHmGlare()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptParalyze(ref defender, aForm);
        }
    }
}
