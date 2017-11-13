using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSharpen : TmHm
    {
        int MYIDNUMBER = 116;
        int deltaAtk = 1;

        public TmHmSharpen()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAtk(deltaAtk, ref attacker, aForm, false);

        }
    }
}
