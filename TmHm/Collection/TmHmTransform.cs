using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmTransform : TmHm
    {
        int MYIDNUMBER = 155;

        public TmHmTransform()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attacker.transform(defender);
            aForm.setTextMessage(attacker.getName() + " Transformed to a " + defender.getName());
        }
    }
}
