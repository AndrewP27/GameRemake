using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmWhirlwind : TmHm
    {
        int MYIDNUMBER = 162;
        public TmHmWhirlwind()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            aForm.ForceNewPkm(defender.getTrainerSlot());
        }
    }
}
