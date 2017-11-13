using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemAwakening : Item
    {
        int ITEM_ID = 8;

        public ItemAwakening()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            slpHeal(ref aTrainer, aPokeSlot, aForm);
        }
    }
}
