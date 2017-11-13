using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSky_Attack : TmHm
    {
        int MYIDNUMBER = 119;
        double chanceOfFlinch = 0.3;
        int useNum;
        public TmHmSky_Attack()
        {
            SetUpInit(MYIDNUMBER);
            useNum = 0;
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveRecharge(ref attacker, ref defender, aForm, ref useNum);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
            if (checkProb(chanceOfFlinch))
                attemptFlinch(ref defender, aForm);
        }
        
    }
}
