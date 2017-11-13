using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmGrowth : TmHm
    {
        int MYIDNUMBER = 54;
        int deltaAtk = 1;
        int deltaSpecAtk = 1;

        public TmHmGrowth()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAtk(deltaAtk, ref attacker, aForm, false);
            changeSpecAtk(deltaSpecAtk, ref attacker, aForm, false);

        }
    }
}
