using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmLeer : TmHm
    {
        int MYIDNUMBER = 74;
        int deltaDef = -1;
        public TmHmLeer()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(deltaDef, ref defender, aForm);

        }
    }
}
