using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSupersonic : TmHm
    {
        int MYIDNUMBER = 140;
        public TmHmSupersonic()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptConfuse(ref defender, aForm);
        }
    }
}
