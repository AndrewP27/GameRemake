using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmHypnosis : TmHm
    {
        int MYIDNUMBER = 66;

        public TmHmHypnosis()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptSleep(ref defender, aForm);
        }
    }
}
