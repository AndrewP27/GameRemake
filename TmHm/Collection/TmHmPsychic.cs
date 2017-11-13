using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPsychic : TmHm
    {
        int MYIDNUMBER = 98;
        int CHANGE_SPEC_DEF = -1;
        double percentChanceLowerDef = .1;

        public TmHmPsychic()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceLowerDef))
                changeSpecDef(CHANGE_SPEC_DEF, ref defender, aForm);
        }
    }
}
