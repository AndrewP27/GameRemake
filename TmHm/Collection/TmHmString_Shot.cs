using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmString_Shot : TmHm
    {
        int MYIDNUMBER = 134;
        int DELTASPD = -2;

        public TmHmString_Shot()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeSpeed(DELTASPD, ref defender, aForm);
        }
    }
}
