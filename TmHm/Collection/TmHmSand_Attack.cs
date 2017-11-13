using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSand_Attack : TmHm
    {
        int MYIDNUMBER = 111;
        int DELTAACC = -1;

        public TmHmSand_Attack()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAcc(DELTAACC, ref defender, aForm);
        }
    }
}
