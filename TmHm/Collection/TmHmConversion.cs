using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmConversion : TmHm
    {
        int MYIDNUMBER = 23;

        public TmHmConversion()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attacker.setTempType(attacker.getMove(0).getType());
        }
    }
}
