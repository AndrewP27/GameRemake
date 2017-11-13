using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSleep_Powder : TmHm
    {
        int MYIDNUMBER = 122;

        public TmHmSleep_Powder()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptSleep(ref defender, aForm);
        }
    }
}
