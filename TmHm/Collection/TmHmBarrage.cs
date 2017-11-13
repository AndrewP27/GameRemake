using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{

    // Note Accuracy is 100% to provide Accuracy in THIS Class
    class TmHmBarrage : TmHm
    {
        double myAcc = 0.85;
        int MYIDNUMBER = 7;
        public TmHmBarrage()
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
