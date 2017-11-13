using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmMirror_Move : TmHm
    {
        int MYIDNUMBER = 86;

        public TmHmMirror_Move()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            TmHm TmHmUsed = null;

            int lastMoveSlot = defender.getLastMoveSlot();

            if (lastMoveSlot < 0)
            {
                List<int> validMoves = defender.askValidTmHmNum();
                int chosenMove = Utilities.chooseNumber(0, validMoves.Count - 1);
                TmHmUsed = defender.getMove(chosenMove);
            }
            else
            {
                TmHmUsed = defender.getMove(lastMoveSlot);
            }

            TmHmUsed.preMove(ref attacker, ref defender, aForm);
        }
    }
}
