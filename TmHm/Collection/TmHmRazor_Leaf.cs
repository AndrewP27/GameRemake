using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmRazor_Leaf : TmHm
    {
        int MYIDNUMBER = 102;

        public TmHmRazor_Leaf()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
        }

        protected override bool checkCrit(ref Pokemon attacker)
        {
            if (chooseNumber(0, 800) < 100 * attacker.getCrit())
                return true;

            return false;
        }
    }
}
