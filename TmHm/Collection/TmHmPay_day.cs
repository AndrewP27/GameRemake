using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmPay_day : TmHm
    {
        int MYIDNUMBER = 89;
        public TmHmPay_day()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
            aForm.setTextMessage("Money Flies Everywhere!!!!!!!!!!!");
        }
    }
}
