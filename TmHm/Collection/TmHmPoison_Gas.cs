using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPoison_Gas : TmHm
    {
        int MYIDNUMBER = 93;

        public TmHmPoison_Gas()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptPoison(ref defender, aForm);
        }
    }
}
