using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmClamp : TmHm
    {
        int MYIDNUMBER = 18;
        int totalTurns;
        int turnNum;
        double percentHPDamage = .0625;
        public TmHmClamp()
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
            useMoveLock(ref attacker, ref defender, ref turnNum, ref totalTurns, percentHPDamage, aForm);
        }
        public override bool resetPersistant()
        {
            turnNum = 0;
            return true;
        }
    }
}
