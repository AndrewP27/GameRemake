using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmRoar : TmHm
    {
        int MYIDNUMBER = 107;

        public TmHmRoar()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            aForm.ForceNewPkm(defender.getTrainerSlot());
        }
    }
}
