using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmStun_Spore : TmHm
    {
        int MYIDNUMBER = 122;

        public TmHmStun_Spore()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attemptParalyze(ref defender, aForm);
        }
    }
}
