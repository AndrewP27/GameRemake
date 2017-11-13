using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    static class BattleManager
    {
        public static void choseSwitch(int newPokeSlot, ref Trainer trainer1, ref Trainer trainer2, Form1 aForm)
        {
            if (newPokeSlot == trainer1.askPreviousSlot() && trainer1.myBag.getSlot(newPokeSlot) != null)
                return;

            if (newPokeSlot < 0)
                return;

            trainer1.setAction(Trainer.Action.Swap_Pkm, newPokeSlot, -1);

            aForm.updateData();

            trainer2.PromptAINextMove(ref trainer1, ref trainer2);

            action(ref trainer1, ref trainer2, aForm);


        }

        public static void choseItem(int itemSlot, ref Trainer trainer1, ref Trainer trainer2, Form1 aForm)
        {
            trainer1.setAction(Trainer.Action.Use_Item, itemSlot, -1);

            aForm.updateData();

            trainer2.PromptAINextMove(ref trainer1, ref trainer2);

            action(ref trainer1, ref trainer2, aForm);
        }

        public static void choseMove(int moveSlotNumber, ref Trainer trainer1, ref Trainer trainer2, Form1 aForm)
        {

            trainer1.setAction(Trainer.Action.Use_TmHm, moveSlotNumber, -1);

            if (trainer1.checkDisabled(moveSlotNumber))
            {
                if (trainer1.checkRemainingPP(moveSlotNumber))
                {
                    // WIP Will be AI Choice HERE
                    trainer2.PromptAINextMove(ref trainer1, ref trainer2);

                    action(ref trainer1, ref trainer2, aForm);
                }
                else
                    aForm.setTextMessage(trainer1.activePokemon.getMoveName(moveSlotNumber) + " is no longer avaliable!");

            }
            else
                aForm.setTextMessage(trainer1.activePokemon.getMoveName(moveSlotNumber) + " is Disabled!");
            
        }

        public static void struggle(ref Trainer trainer1, ref Trainer trainer2, Form1 aForm)
        {
            trainer1.setAction(Trainer.Action.Struggle, -1, -1);

            // WIP Will be AI Choice HERE
            trainer2.PromptAINextMove(ref trainer1, ref trainer2);

            action(ref trainer1, ref trainer2, aForm);
        }

        private static void action(ref Trainer trainer1, ref Trainer trainer2, Form1 aForm)
        {
            bool stillAlive;

            // Chose who is first
            if (isTrainer1First(trainer1, trainer2))
            {
                int preMoveTrainerSlot = trainer2.askPreviousSlot();

                // Use moves
                stillAlive = trainer1.useAction(ref trainer1, ref trainer2, aForm) && preMoveTrainerSlot == trainer2.askPreviousSlot();
                if (stillAlive)
                    stillAlive = trainer2.useAction(ref trainer2, ref trainer1, aForm);
            }
            else
            {
                int preMoveTrainerSlot = trainer1.askPreviousSlot();

                // Use moves
                stillAlive = trainer2.useAction(ref trainer2, ref trainer1, aForm) && preMoveTrainerSlot == trainer1.askPreviousSlot();
                if (stillAlive)
                    stillAlive = trainer1.useAction(ref trainer1, ref trainer2, aForm);
            }



            if (stillAlive)
            {
                postAttacks(ref trainer1, ref trainer2, aForm);
            }
            else
            {
                if (!trainer1.activePokemon.isAlive())
                {
                    if (trainer1.askNumPokemon() > 0)
                    {
                        if (trainer2.activePokemon.askPersistant() && trainer2.activePokemon.getPersistantMove().resetPersistant())
                            trainer2.activePokemon.setPersistantMove(null);

                        aForm.onDeath(1);
                        aForm.setTextMessage(trainer1.activePokemon.getName() + " has Fainted!!");

                        

                        SwapPkmForm swapping = new SwapPkmForm(trainer1, true);
                        swapping.ShowDialog();

                        int newSlot = swapping.SlotChoice;

                        trainer1.setActivePokemon(newSlot);

                        aForm.ResetPics();
                    }
                    else
                        aForm.endBattle();
                }
                if (!trainer2.activePokemon.isAlive())
                {
                    if (trainer2.askNumPokemon() > 0)
                    {
                        if (trainer1.activePokemon.askPersistant() && trainer1.activePokemon.getPersistantMove().resetPersistant())
                            trainer1.activePokemon.setPersistantMove(null);

                        aForm.onDeath(2);
                        aForm.setTextMessage(trainer2.activePokemon.getName() + " has Fainted!!");
                        trainer2.PromptAINextPkm(ref trainer1, ref trainer2);
                        aForm.ResetPics();
                    }
                    else
                        aForm.endBattle();
                }
            }


            aForm.updateData();
        }

        private static bool isTrainer1First(Trainer trainer1,Trainer trainer2)
        {
            int trainer1Priority = trainer1.askPriority();
            int trainer2Priority = trainer2.askPriority();

            // Check Priorities
            if (trainer1Priority > trainer2Priority)
                return true;
            else if (trainer1Priority < trainer2Priority)
                return false;

            if (trainer1.askSpeed() > trainer2.askSpeed())
                return true;
            else if (trainer1.askSpeed() < trainer2.askSpeed())
                return false;

            if (Utilities.chooseNumber(1, 2) == 1)
                return true;
            else
                return false;
        }

        private static void postAttacks(ref Trainer trainer1, ref Trainer trainer2, Form1 aForm)
        {

            trainer1.postAttack(aForm, ref trainer2);
            trainer2.postAttack(aForm, ref trainer1);
        }
    }
}
