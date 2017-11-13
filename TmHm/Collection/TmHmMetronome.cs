using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmMetronome : TmHm
    {
        int MYIDNUMBER = 83;

        TmHm TmHmUsed = null;

        public TmHmMetronome()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveMultiHit(ref attacker, ref defender, aForm);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (TmHmUsed == null || !attacker.askPersistant())
            {
                TmHmUsed = Utilities.getMoveObj(chooseNumber(1, Utilities.getNumTmHm()));
            }

            TmHmUsed.preMove(ref attacker, ref defender, aForm);
        }
    }
}
