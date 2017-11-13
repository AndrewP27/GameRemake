using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public class PokeBag
    {
        public Pokemon[] myPokemon;
        int NUM_POKEMON_IN_BAG = 6;

        public PokeBag()
        {
            myPokemon = new Pokemon[NUM_POKEMON_IN_BAG];

            for (int i = 0; i < myPokemon.Length; i++)
            {
                myPokemon[i] = null;
            }
        }

        public Pokemon getSlot(int slotNum)
        {
            if (slotNum < myPokemon.Length && slotNum >= 0)
                return myPokemon[slotNum];
            else
                return null;
        }

        public void setPokeSlot(Pokemon aPokemon, int aSlot)
        {
            if (aSlot < NUM_POKEMON_IN_BAG && aSlot >= 0)
                myPokemon[aSlot] = aPokemon;
        }
        public void setNewMove(int pokeSlot, int moveID, int moveSlot)
        {
            if (pokeSlot <= NUM_POKEMON_IN_BAG && pokeSlot >= 0)
                myPokemon[pokeSlot].setNewMove(moveID, moveSlot);
            else
                throw (new System.Exception("Pokemon Slot Invalid"));
        }
    }
}
