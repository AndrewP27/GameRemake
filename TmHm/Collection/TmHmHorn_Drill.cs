using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmHorn_Drill : TmHm
    {
        int MYIDNUMBER = 62;

        public TmHmHorn_Drill()
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
