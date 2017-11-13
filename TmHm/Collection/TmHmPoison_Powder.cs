using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPoison_Powder : TmHm
    {
        int MYIDNUMBER = 94;

        public TmHmPoison_Powder()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptPoison(ref defender, aForm);
        }
    }
}
