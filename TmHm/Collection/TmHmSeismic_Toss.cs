using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSeismic_Toss : TmHm
    {
        int MYIDNUMBER = 114;

        public TmHmSeismic_Toss()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            double damageDealt = defender.getLevel();
            applyDamageExact(ref attacker, ref defender, aForm, damageDealt);
        }
    }
}
