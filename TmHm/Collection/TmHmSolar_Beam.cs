using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSolar_Beam : TmHm
    {
        int MYIDNUMBER = 127;
        int useNum;
        public TmHmSolar_Beam()
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
        }
        
    }
}
