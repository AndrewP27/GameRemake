using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemX_Speed : Item
    {
        int ITEM_ID = 17;
        int aStageAmount = 1;

        public ItemX_Speed()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            raiseSpd(ref aTrainer, aPokeSlot, aStageAmount, aForm);
        }
    }
}
