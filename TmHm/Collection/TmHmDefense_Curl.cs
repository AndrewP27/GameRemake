using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDefense_Curl : TmHm
    {
        int MYIDNUMBER = 27;
        int DELTADEF = 1;

        public TmHmDefense_Curl()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(DELTADEF, ref attacker, aForm, false);
        }
    }
}
