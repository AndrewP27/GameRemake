using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmRest : TmHm
    {
        int MYIDNUMBER = 106;

        public TmHmRest()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            heal(ref attacker, attacker.getMaxHP(), aForm);
            attacker.sleep(aForm);
        }
    }
}
