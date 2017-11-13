using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmBarrier : TmHm
    {
        int MYIDNUMBER = 8;
        int DELTADEF = 2;

        public TmHmBarrier()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(DELTADEF, ref attacker, aForm, false);
        }
    }
}
