using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class ItemAntidote : Item
    {
        int ITEM_ID = 5;

        public ItemAntidote()
        {
            SetUpInit(ITEM_ID);
        }

        protected override void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            pznHeal(ref aTrainer, aPokeSlot, aForm);
        }
    }
}
