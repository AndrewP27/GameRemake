using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDisable : TmHm
    {
        int MYIDNUMBER = 29;

        public TmHmDisable()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            int lastMoveSlot = defender.getLastMoveSlot();

            if(lastMoveSlot <0)
            {
                List<int> validMoves = defender.askValidTmHmNum();
                int chosenMove = Utilities.chooseNumber(0, validMoves.Count - 1);

                defender.setDisabled(validMoves.ElementAt(chosenMove));
                aForm.setTextMessage(defender.getMoveName(chosenMove) + " is Disabled");
            }
            else
            {
                defender.setDisabled(lastMoveSlot);

                aForm.setTextMessage(defender.getMoveName(lastMoveSlot) + " is Disabled");
            }
        }
    }
}
