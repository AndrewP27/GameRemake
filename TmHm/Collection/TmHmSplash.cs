using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSplash : TmHm
    {
        int MYIDNUMBER = 130;

        public TmHmSplash()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            aForm.setTextMessage("CONGRATS, You did APSOLUTLY NOTHING!");
        }
    }
}
