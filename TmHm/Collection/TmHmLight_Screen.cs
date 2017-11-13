using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmLight_Screen : TmHm
    {
        int MYIDNUMBER = 76;

        public TmHmLight_Screen()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attacker.lightScreen(aForm);
        }
    }
}
