﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class DefensiveAI
    {
        public int choseNewPkm(ref Trainer trainer1, ref Trainer trainer2)
        {
            if (trainer2.myBag.myPokemon[0].isAlive())
                return 0;
            if (trainer2.myBag.myPokemon[1].isAlive())
                return 1;
            if (trainer2.myBag.myPokemon[2].isAlive())
                return 2;
            if (trainer2.myBag.myPokemon[3].isAlive())
                return 3;
            if (trainer2.myBag.myPokemon[4].isAlive())
                return 4;
            if (trainer2.myBag.myPokemon[5].isAlive())
                return 5;

            else return -1;
        }

        public int choseNewPkmBanned(ref Trainer trainer1, ref Trainer trainer2, int bannedNum)
        {
            if (trainer2.myBag.myPokemon[0].isAlive() && 0 != bannedNum)
                return 0;
            if (trainer2.myBag.myPokemon[1].isAlive() && 1 != bannedNum)
                return 1;
            if (trainer2.myBag.myPokemon[2].isAlive() && 2 != bannedNum)
                return 2;
            if (trainer2.myBag.myPokemon[3].isAlive() && 3 != bannedNum)
                return 3;
            if (trainer2.myBag.myPokemon[4].isAlive() && 4 != bannedNum)
                return 4;
            if (trainer2.myBag.myPokemon[5].isAlive() && 5 != bannedNum)
                return 5;

            else return -1;
        }

    }
}
