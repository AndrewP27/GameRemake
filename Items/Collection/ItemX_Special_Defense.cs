using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemX_Special_Defense : Item
    {
        int ITEM_ID = 16;
        int aStageAmount = 1;

        public ItemX_Special_Defense()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            raiseSpecD(ref aTrainer, aPokeSlot, aStageAmount, aForm);
        }
    }
}
