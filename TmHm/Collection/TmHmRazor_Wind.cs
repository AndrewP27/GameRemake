using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmRazor_Wind :TmHm
    {
        int MYIDNUMBER = 103;
        int useNum;

        public TmHmRazor_Wind()
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

        protected override bool checkCrit(ref Pokemon attacker)
        {
            if (chooseNumber(0, 800) < 100 * attacker.getCrit())
                return true;

            return false;
        }
        
    }
}
