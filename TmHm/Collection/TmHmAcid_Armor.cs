using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmAcid_Armor : TmHm
    {
        int MYIDNUMBER = 3;
        int deltaDef = 2;

        public TmHmAcid_Armor()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeDef(deltaDef, ref attacker, aForm, false);
            
        }
    }
}
