using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPsywave : TmHm
    {
        int MYIDNUMBER = 99;

        public TmHmPsywave()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            double damageDealt = chooseNumber(50, 150) * .01 * defender.getLevel();
            applyDamageExact(ref attacker, ref defender, aForm, damageDealt);
        }
    }
}
