using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFissure : TmHm
    {
        int MYIDNUMBER = 45;

        public TmHmFissure()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveMultiHit(ref attacker, ref defender, aForm);
        }
        

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            useMoveFatal(ref attacker, ref defender, aForm);
        }
    }
}
