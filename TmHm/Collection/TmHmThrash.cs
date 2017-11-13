using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmThrash : TmHm
    {
        int MYIDNUMBER = 148;
        int totalTurns;
        int turnNum;
        public TmHmThrash()
        {
            SetUpInit(MYIDNUMBER);
            turnNum = 0;
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveLock(ref attacker, ref defender, aForm);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            useMoveMultiTurnHit(ref attacker, ref defender, ref turnNum, ref totalTurns, aForm);
        }
        
    }
}
