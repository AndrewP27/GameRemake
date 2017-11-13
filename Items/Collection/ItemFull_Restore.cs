using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemFull_Restore : Item
    {
        int ITEM_ID = 11;

        public ItemFull_Restore()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            pznHeal(ref aTrainer, aPokeSlot, aForm);
            brnHeal(ref aTrainer, aPokeSlot, aForm);
            fznHeal(ref aTrainer, aPokeSlot, aForm);
            slpHeal(ref aTrainer, aPokeSlot, aForm);
            cfzHeal(ref aTrainer, aPokeSlot, aForm);
            healPokemon(ref aTrainer, aPokeSlot, int.MaxValue, aForm);
        }
    }
}
