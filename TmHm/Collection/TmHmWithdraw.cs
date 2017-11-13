using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmWithdraw : TmHm
    {
        int MYIDNUMBER = 164;
        int deltaDef = 1;

        public TmHmWithdraw()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(deltaDef, ref attacker, aForm, false);

        }
    }
}
