using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmHaze : TmHm
    {
        int MYIDNUMBER = 58;

        public TmHmHaze()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attacker.resetStatus();
            defender.resetStatus();
        }
    }
}
