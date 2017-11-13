using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemPotion : Item
    {
        int ITEM_ID = 1;
        int aHealAmount = 20;

        public ItemPotion()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            healPokemon(ref aTrainer, aPokeSlot, aHealAmount, aForm);
        }
    }
}
