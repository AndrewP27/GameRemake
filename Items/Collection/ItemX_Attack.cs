using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemX_Attack : Item
    {
        int ITEM_ID = 13;
        int aStageAmount = 1;

        public ItemX_Attack()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            raiseAtk(ref aTrainer, aPokeSlot, aStageAmount, aForm);
        }
    }
}
