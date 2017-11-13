using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSubstitute : TmHm
    {
        int MYIDNUMBER = 138;

        public TmHmSubstitute()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            attacker.substitute(ref attacker, this, aForm);
        }
    }
}
