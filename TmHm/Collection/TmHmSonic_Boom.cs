using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSonic_Boom : TmHm
    {
        int MYIDNUMBER = 128;
        double damageDealt = 20;

        public TmHmSonic_Boom()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamageExact(ref attacker, ref defender, aForm, damageDealt);
        }
    }
}
