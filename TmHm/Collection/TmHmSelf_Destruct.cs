using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class TmHmSelf_Destruct : TmHm
    {
        int MYIDNUMBER = 115;
        public TmHmSelf_Destruct()
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
