using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmEarthquake : TmHm
    {
        int MYIDNUMBER = 38;

        public TmHmEarthquake()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
        }

        protected override double applyDamage(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (defender.getSafety() && defender.getPersistantMove().getName() != "Dig")
            {
                aForm.setTextMessage(defender.getName() + " is not able to be hit!");
            }

            if (!(getCat() == 1 || getCat() == 2))
                return 0;

            double atkStat = getAtkStat(attacker);
            double defStat = getDefStat(defender); ;

            int critValue = 1;

            if (checkCrit(ref attacker))
                critValue = 2;

            double multiplier = Utilities.Effectiveness(defender.getPkmType1(), getType());

            if (defender.getPkmType2() > 0)
                multiplier *= Utilities.Effectiveness(defender.getPkmType2(), getType());

            if(multiplier == 0)
            {
                aForm.setTextMessage(getName() + " can not hurt " + defender.getName());
                return 0;
            }

            double damage = ((((attacker.getLevel() * .4 * critValue) + 2) * atkStat * getPower() / 50 / defStat) + 2) * multiplier * Utilities.chooseNumber(217, 255) / 255;

            defender.damagePkmIncludingSub(damage, this, aForm, ref defender);

            aForm.setDamageMessage(attacker.getName(), getName(), defender.getTrainerSlot());

            if (multiplier > 1)
                aForm.setTextMessage("It is Super Effective!");
            else if (multiplier < 1)
                aForm.setTextMessage("It is not very effective.");

            return damage;
        }
    }
}
