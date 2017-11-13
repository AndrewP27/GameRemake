using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemX_Special : Item
    {
        int ITEM_ID = 15;
        int aStageAmount = 1;

        public ItemX_Special()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            raiseSpecA(ref aTrainer, aPokeSlot, aStageAmount, aForm);
        }
    }
}
