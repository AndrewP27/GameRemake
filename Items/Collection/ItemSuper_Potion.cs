using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemSuper_Potion : Item
    {
        int ITEM_ID = 2;
        int aHealAmount = 60;

        public ItemSuper_Potion()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            healPokemon(ref aTrainer, aPokeSlot, aHealAmount, aForm);
        }
    }
}
