using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmLow_Kick : TmHm
    {
        int MYIDNUMBER = 78;
        int myPower = 0;

        public TmHmLow_Kick()
        {
            SetUpInit(MYIDNUMBER);
        }
        protected override int getPower()
        {
            if (myPower == 0)
                throw (new Exception("Power has not been initalized!"));

            return myPower;
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            double defenderWeight = defender.getWeight();
            if (defenderWeight < 10.0)
                myPower = 20;
            else if (defenderWeight < 25.0)
                myPower = 40;
            else if (defenderWeight < 50.0)
                myPower = 60;
            else if (defenderWeight < 100.0)
                myPower = 80;
            else if (defenderWeight < 200.0)
                myPower = 100;
            else
                myPower = 120;

            applyDamage(ref attacker, ref defender, aForm);
        }
    }
}
