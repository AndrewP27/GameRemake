using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmLeech_Seed : TmHm
    {
        int MYIDNUMBER = 73;

        public TmHmLeech_Seed()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (defender.getPkmType1() != 5 && defender.getPkmType2() != 5)
                defender.seed(aForm);
            else
                aForm.setTextMessage("Leech Seed is not effective!");
        }
    }
}
