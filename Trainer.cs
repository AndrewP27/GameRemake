using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public class Trainer
    {
        string myName;
        public Pokemon activePokemon = null;
        int previousSlot;
        public PokeBag myBag;
        public ItemManager myItems;
        int MAX_TMHM_PRIORITY = 5;
        AI myAI = new RandomAI();
        public enum Action { Use_Item, Use_TmHm, Swap_Pkm, Attempt_Run, Struggle };

        Action nextAction;
        int switchSlot = -1;
        int itemSlot = -1;
        int pkmSlot = -1;
        int TmHmSlot = -1;

        int TrainerSlot;


        public Trainer(string aName, PokeBag aBag, int aTrainerSlot)
        {
            myName = aName;
            myBag = aBag;
            TrainerSlot = aTrainerSlot;
            myItems = new ItemManager();
        }

        public Trainer(string aName, int aTrainerSlot)
        {
            myName = aName;
            TrainerSlot = aTrainerSlot;
            myBag = new PokeBag();
            myItems = new ItemManager();
        }

        public int askNumPokemon()
        {
            int count = 0;
            for (int i = 0; i < myBag.myPokemon.Length; i++)
            {
                if (myBag.myPokemon[i] != null && myBag.myPokemon[i].isAlive())
                    count++;
            }

            return count;
        }

        public void PromptAINextMove(ref Trainer trainer1, ref Trainer trainer2)
        {
            myAI.choseNextAction(ref trainer1, ref trainer2);
        }

        public void PromptAINextPkm(ref Trainer trainer1, ref Trainer trainer2)
        {
            int nextPkm = myAI.choseNewPkm(ref trainer1, ref trainer2);
            swapPkm(nextPkm);
        }

        public void PromptAINextPkmBanned(ref Trainer trainer1, ref Trainer trainer2, int bannedNum)
        {
            int nextPkm = myAI.choseNewPkmBanned(ref trainer1, ref trainer2, bannedNum);
            swapPkm(nextPkm);
        }

        public int askPreviousSlot()
        {
            return previousSlot;
        }

        public List<Item> getMyItems()
        {
            return myItems.getMyItems();
        }

        public void addNewItem(int idNum, int count)
        {
            myItems.addNewItem(idNum, count);
        }

        public void useItem(int aSlotNum, ref Trainer aTrainer, Form1 aForm)
        {
            myItems.useItem(aSlotNum, ref aTrainer, aForm);
        }

        public Pokemon getPokeSlot(int slotNum)
        {
            return myBag.getSlot(slotNum);
        }

        public void setPokeSlot(Pokemon aPokemon, int aSlot)
        {
            myBag.setPokeSlot(aPokemon, aSlot);
        }

        public void setNewMove(int pokeSlot, int moveID, int moveSlot)
        {
            myBag.setNewMove(pokeSlot, moveID, moveSlot);
        }

        public void setActivePokemon(int pokeSlot)
        {
            if (activePokemon != null)
                myBag.setPokeSlot(activePokemon, previousSlot);

            activePokemon = myBag.getSlot(pokeSlot);
            previousSlot = pokeSlot;
        }

        public void clearActivePokemon()
        {
            if (activePokemon != null)
                myBag.setPokeSlot(activePokemon, previousSlot);

            activePokemon = null;
        }

        public bool checkDisabled(int aMoveSlotNumber)
        {
            return !activePokemon.askDisabled(aMoveSlotNumber);
        }

        public void setAction(Action aAction, int primaryNumber, int secondaryNumber)
        {
            switchSlot = -1;
            itemSlot = -1;
            pkmSlot = -1;
            TmHmSlot = -1;
            switch (aAction)
            {
                case Action.Use_Item:
                    nextAction = Action.Use_Item;
                    itemSlot = primaryNumber;
                    break;
                case Action.Use_TmHm:
                    nextAction = Action.Use_TmHm;
                    TmHmSlot = primaryNumber;
                    break;
                case Action.Swap_Pkm:
                    nextAction = Action.Swap_Pkm;
                    switchSlot = primaryNumber;
                    break;
                case Action.Attempt_Run:
                    nextAction = Action.Attempt_Run;
                    break;
                case Action.Struggle:
                    nextAction = Action.Struggle;
                    break;
                default:
                    break;
            }
        }

        public int askPriority()
        {
            if(nextAction != Action.Use_TmHm)
            {
                return MAX_TMHM_PRIORITY + 1;
            }
            else
            {
                // Get Moves
                TmHm trainerMove = activePokemon.getPersistantMove();
                if (trainerMove == null)
                    trainerMove = activePokemon.getMove(TmHmSlot);

                return trainerMove.getPriority();
            }
        }

        public double askSpeed()
        {
            return activePokemon.getSpeed();
        }

        public bool useAction(ref Trainer attacker, ref Trainer defender, Form1 aForm)
        {
            switch (nextAction)
            {
                case Action.Use_Item:
                    attacker.useItem(itemSlot, ref attacker, aForm);
                    break;
                case Action.Use_TmHm:
                    // Use moves
                     useMove(ref attacker, ref defender, TmHmSlot, aForm);
                    break;
                case Action.Swap_Pkm:
                    swapPkm(switchSlot);
                    break;
                case Action.Attempt_Run:

                    break;
                case Action.Struggle:
                    useStruggle(ref attacker, ref defender, aForm);
                    break;
                default:
                    break;
            }

            aForm.updateElements();

            return attacker.activePokemon.isAlive() && defender.activePokemon.isAlive();
        }

        private void swapPkm(int nextPkm)
        {
            myBag.setPokeSlot(activePokemon, previousSlot);
            activePokemon = myBag.getSlot(nextPkm);
            previousSlot = nextPkm;
        }

        private void useMove(ref Trainer attacker, ref Trainer defender, int moveNum, Form1 aForm)
        {
            if (!attacker.activePokemon.tryPersistant(ref attacker.activePokemon, ref defender.activePokemon, aForm))
                attacker.activePokemon.useMove(ref attacker.activePokemon, ref defender.activePokemon, moveNum, aForm);
        }


        private void useStruggle(ref Trainer attacker, ref Trainer defender, Form1 aForm)
        {
            if (!attacker.activePokemon.tryPersistant(ref attacker.activePokemon, ref defender.activePokemon, aForm))
                attacker.activePokemon.useStruggle(ref attacker.activePokemon, ref defender.activePokemon, aForm);
        }

        public string getTmHmString(int aMoveSlot)
        {
            return activePokemon.getTmHmString(aMoveSlot);
        }

        public bool checkRemainingPP(int aSlotNum)
        {
            return activePokemon.checkRemainingPP(aSlotNum);
        }

        public bool askPersistant()
        {
            return activePokemon.askPersistant();
        }

        public void postAttack(Form1 aForm, ref Trainer attacker)
        {
            activePokemon.postAttack(ref activePokemon, aForm, ref attacker.activePokemon);
        }
    }
}
