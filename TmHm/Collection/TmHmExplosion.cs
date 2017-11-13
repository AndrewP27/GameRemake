using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmExplosion : TmHm
    {
        int MYIDNUMBER = 41;

        public TmHmExplosion()
        {
            SetUpInit(MYIDNUMBER);
        }

        protected override void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            applyDamage(ref attacker, ref defender, aForm);

            attacker.kill();

            aForm.updateHPDamage();
        }
    }
}
