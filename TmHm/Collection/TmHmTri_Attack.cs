using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmTri_Attack : TmHm
    {
        int MYIDNUMBER = 156;

        public TmHmTri_Attack()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
            int ranNum = chooseNumber(1, 100);

            if (ranNum < 7)
                attemptBurn(ref defender, aForm);
            else if (ranNum < 14)
                attemptParalyze(ref defender, aForm);
            else if (ranNum < 21)
                attemptFreeze(ref defender, aForm);
        }
    }
}
