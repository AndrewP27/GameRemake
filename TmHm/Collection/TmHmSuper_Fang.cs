using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSuper_Fang : TmHm
    {
        int MYIDNUMBER = 139;

        public TmHmSuper_Fang()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamageExact(ref attacker, ref defender, aForm, defender.getHP());
        }
    }
}
