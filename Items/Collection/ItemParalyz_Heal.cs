using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemParalyz_Heal : Item
    {
        int ITEM_ID = 6;

        public ItemParalyz_Heal()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            przHeal(ref aTrainer, aPokeSlot, aForm);
        }
    }
}
