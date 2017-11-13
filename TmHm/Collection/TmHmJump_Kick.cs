using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmJump_Kick : TmHm
    {
        int MYIDNUMBER = 69;

        public TmHmJump_Kick()
        {
            SetUpInit(MYIDNUMBER);
        }

        public override void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            preMoveCrash(ref attacker, ref defender, aForm);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);
        }
    }
}
