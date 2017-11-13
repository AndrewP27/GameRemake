using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDouble_Kick : TmHm
    {
        int MYIDNUMBER = 31;
        double myAcc = 1;

        public TmHmDouble_Kick()
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
