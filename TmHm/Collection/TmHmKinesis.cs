using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmKinesis : TmHm
    {
        int MYIDNUMBER = 71;
        int DELTAACC = -1;

        public TmHmKinesis()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            changeAcc(DELTAACC, ref defender, aForm);
        }
    }
}
