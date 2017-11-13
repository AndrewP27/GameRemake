using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmRage : TmHm
    {
        int MYIDNUMBER = 101;
        bool hasBeenUsed = false;
        public TmHmRage()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (!hasBeenUsed)
            {
                decrementPP();
                hasBeenUsed = true;
            }
            
            preMoveLock(ref attacker, ref defender, aForm);
            
        }

        public override void onDamage(double damage, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {
            if (hasBeenUsed && self.isAlive())
            {
                aForm.setTextMessage(self.getName() + "'s Rage GROWS!");
                self.changeAtk(1);
            }
            else if (!(self.isAlive()))
                aForm.blockChoice = false;
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attacker.setPersistantMove(this);
            aForm.blockChoice = true;
            if (!(getMyAcc() == -1 || checkHit(ref attacker, ref defender)))
            {
                aForm.setTextMessage(attacker.getName() + " has missed!");
                return;
            }
            applyDamage(ref attacker, ref defender, aForm);
        }
        
    }
}
