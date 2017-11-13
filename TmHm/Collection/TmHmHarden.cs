using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmHarden : TmHm
    {
        int MYIDNUMBER = 57;
        int deltaDef = 1;

        public TmHmHarden()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(deltaDef, ref attacker, aForm, false);

        }
    }
}
