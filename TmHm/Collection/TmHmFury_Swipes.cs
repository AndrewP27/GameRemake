using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFury_Swipes : TmHm
    {
        double myAcc = 0.8;
        int MYIDNUMBER = 51;
        public TmHmFury_Swipes()
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
