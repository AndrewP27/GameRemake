using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSkull_Bash : TmHm
    {
        int MYIDNUMBER = 118;
        int useNum;
        int DELTADEF = 1;
        public TmHmSkull_Bash()
        {
            SetUpInit(MYIDNUMBER);
            useNum = 0;
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (useNum == 0)
                changeDef(DELTADEF, ref attacker, aForm);
            preMoveRecharge(ref attacker, ref defender, aForm, ref useNum);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
        }
        
    }
}
