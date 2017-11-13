using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDragon_Rage : TmHm
    {
        int MYIDNUMBER = 35;
        double damageDealt = 40;

        public TmHmDragon_Rage()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamageExact(ref attacker, ref defender, aForm, damageDealt);
        }
    }
}
