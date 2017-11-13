using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmLovely_Kiss : TmHm
    {
        int MYIDNUMBER = 77;

        public TmHmLovely_Kiss()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptSleep(ref defender, aForm);
        }
    }
}
