using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmCounter : TmHm
    {
        int MYIDNUMBER = 24;
        double lastDamage = 0;

        public TmHmCounter()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveMultiHit(ref attacker, ref defender, aForm);
        }

        public override void onDamage(double damage, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {
            //Check for Physical hit and not confusion, poision, etc..
            if (hittingMove != null && hittingMove.getCat() == 1)
                lastDamage = damage;
            else if (hittingMove != null)
                lastDamage = 0;
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (checkHit(ref attacker, ref defender))
                applyDamage(ref attacker, ref defender, aForm, 2 * lastDamage);
            else
                aForm.setTextMessage(attacker.getName() + " has missed!");
        }
    }
}
