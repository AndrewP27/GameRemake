using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFire_Spin : TmHm
    {
        int MYIDNUMBER = 44;
        int totalTurns;
        int turnNum;
        double percentHPDamage = .0625;
        public TmHmFire_Spin()
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
    }
}
