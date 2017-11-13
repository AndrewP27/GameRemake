using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemX_Defend : Item
    {
        int ITEM_ID = 14;
        int aStageAmount = 1;

        public ItemX_Defend()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            raiseDef(ref aTrainer, aPokeSlot, aStageAmount, aForm);
        }
    }
}
