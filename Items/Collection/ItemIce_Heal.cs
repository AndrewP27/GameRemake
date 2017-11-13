using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemIce_Heal : Item
    {
        int ITEM_ID = 7;

        public ItemIce_Heal()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            fznHeal(ref aTrainer, aPokeSlot, aForm);
        }
    }
}
