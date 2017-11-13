using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmScreech : TmHm
    {
        int MYIDNUMBER = 113;
        int DELTADEF = -2;

        public TmHmScreech()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(DELTADEF, ref defender, aForm);
        }
    }
}
