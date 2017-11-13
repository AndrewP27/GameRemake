using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmAcid : TmHm
    {
        int MYIDNUMBER = 2;
        double percentChanceLowerDefense = .332;
        int DeltaDef = -1;

        public TmHmAcid()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceLowerDefense))
                changeDef(DeltaDef, ref defender, aForm);
            
        }
    }
}
