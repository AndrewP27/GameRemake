using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmConfuse_Ray : TmHm
    {
        int MYIDNUMBER = 20;

        public TmHmConfuse_Ray()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptConfuse(ref defender, aForm);
        }
    }
}
