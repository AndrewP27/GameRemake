using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDouble_Slap : TmHm
    {
        double myAcc = 0.85;
        int MYIDNUMBER = 32;
        public TmHmDouble_Slap()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveMultiHit(ref attacker, ref defender, aForm);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            useMoveMultiHit(ref attacker, ref defender, myAcc, aForm);
        }
    }
}
