using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmStomp : TmHm
    {
        int MYIDNUMBER = 132;
        double percentChanceFlinch = .3;
        bool defenderIsMin = false;

        public TmHmStomp()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override int getPower()
        {
            if (defenderIsMin)
                return 130;
            else
                return base.getPower();
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            defenderIsMin = defender.getIsMinimized();

            applyDamage(ref attacker, ref defender, aForm);

            if (checkProb(percentChanceFlinch))
                defender.flinch();
        }
    }
}
