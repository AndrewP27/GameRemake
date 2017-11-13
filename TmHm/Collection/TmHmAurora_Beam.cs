using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmAurora_Beam : TmHm
    {
        int MYIDNUMBER = 6;

        public TmHmAurora_Beam()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {

            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(.1))
                changeAtk(-1, ref defender, aForm);
        }
    }
}
