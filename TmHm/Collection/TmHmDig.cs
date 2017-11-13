using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmDig : TmHm
    {
        int MYIDNUMBER = 28;
        bool isFirstUse = true;

        public TmHmDig()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveLock(ref attacker, ref defender, aForm);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {

            if(isFirstUse)
            {
                attacker.setPersistantMove(this);
                attacker.setSafety(true);
                isFirstUse = false;
                aForm.burySprite(attacker.getTrainerSlot());
                aForm.setTextMessage(attacker.getName() + " Dug into the Ground");
            }
            else
            {
                attacker.setPersistantMove(null);
                attacker.setSafety(false);
                isFirstUse = true;
                aForm.digUpSprite(attacker.getTrainerSlot());
                applyDamage(ref attacker, ref defender, aForm);
            }

        }
        
    }
}
