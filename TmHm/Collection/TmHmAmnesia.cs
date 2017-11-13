using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmAmnesia : TmHm
    {
        int MYIDNUMBER = 5;
        int DELTASPECDEF = 2;

        public TmHmAmnesia()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeSpecDef(DELTASPECDEF, ref attacker, aForm, false);
        }
    }
}
