using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmFly : TmHm
    {
        int MYIDNUMBER = 48;
        bool isFirstUse = true;

        public TmHmFly()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveLock(ref attacker, ref defender, aForm);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {

            if (isFirstUse)
            {
                attacker.setPersistantMove(this);
                attacker.setSafety(true);
                isFirstUse = false;
                aForm.FlySprite(attacker.getTrainerSlot());
                aForm.setTextMessage(attacker.getName() + " Flew in the Sky");
            }
            else
            {
                attacker.setPersistantMove(null);
                attacker.setSafety(false);
                isFirstUse = true;
                aForm.FlyDownSprite(attacker.getTrainerSlot());
                applyDamage(ref attacker, ref defender, aForm);
            }

        }
        
    }
}
