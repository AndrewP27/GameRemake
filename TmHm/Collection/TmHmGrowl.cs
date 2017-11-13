using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmGrowl : TmHm
    {
        int MYIDNUMBER = 53;
        int deltaAtk = -1;

        public TmHmGrowl()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAtk(deltaAtk, ref defender, aForm);

        }
    }
}
