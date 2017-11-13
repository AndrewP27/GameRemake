using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSwords_Dance : TmHm
    {
        int MYIDNUMBER = 143;
        int deltaAtk = 2;

        public TmHmSwords_Dance()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAtk(deltaAtk, ref attacker, aForm, false);

        }
    }
}
