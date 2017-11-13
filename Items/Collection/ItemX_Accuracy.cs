using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemX_Accuracy : Item
    {
        int ITEM_ID = 12;
        int aStageAmount = 1;

        public ItemX_Accuracy()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            raiseAcc(ref aTrainer, aPokeSlot, aStageAmount, aForm);
        }

    }
}
