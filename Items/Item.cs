using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public abstract class Item
    {
        private int count = 0;
        private string myName;
        private string myDesc;
        private int myidNum;
        private bool useInBattle;

        public void SetUpInit(int Item_Id_Number)
        {
            myName = UtilitiesItemTable.getItemName(Item_Id_Number);
            myDesc = UtilitiesItemTable.getItemDescription(Item_Id_Number);
            double[] myStats = UtilitiesItemTable.getItemStats(Item_Id_Number);

            useInBattle = 1 == myStats[0];
            myidNum = Item_Id_Number;
        }

        public int getID()
        {
            return myidNum;
        }

        public bool askUseInBattle()
        {
            return useInBattle;
        }

        public int getCount()
        {
            return count;
        }

        public string getName()
        {
            return myName;
        }

        public string getDescription()
        {
            return myDesc;
        }

        public void setCount(int aCount)
        {
            count = aCount;
        }

        private void checkCount()
        {
            if (count <= 0)
                throw new Exception("Item Used Past Count");

            count--;
        }

        private int askForPokemonSlot(ref Trainer aTrainer)
        {
            SwapPkmForm swapping = new SwapPkmForm(aTrainer, true);
            swapping.ShowDialog();

            return swapping.SlotChoice;
        }

        public virtual void preUseItem(ref Trainer aTrainer, Form1 aForm)
        {
            checkCount();

            int selectedPok = askForPokemonSlot(ref aTrainer);

            useItem(ref aTrainer, selectedPok, aForm);
        }

        protected abstract void useItem(ref Trainer aTrainer, int aPokeSlot, Form1 aForm);

        protected void healPokemon(ref Trainer aTrainer, int aPokeSlot, double anAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].heal(anAmount);
            aForm.healMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName(), myName);
        }

        protected void pznHeal(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            if (aTrainer.myBag.myPokemon[aPokeSlot].isPoisoned())
            {
                aTrainer.myBag.myPokemon[aPokeSlot].pznHeal();
                aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " is cured from poison!");
                aForm.updateData();
            }
            else
                aForm.setTextMessage(myName + " does nothing!");
        }

        protected void brnHeal(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            if (aTrainer.myBag.myPokemon[aPokeSlot].isBurned())
            {
                aTrainer.myBag.myPokemon[aPokeSlot].brnHeal();
                aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " is cured from their burns!");
                aForm.updateData();
            }
            else
                aForm.setTextMessage(myName + " does nothing!");
        }

        protected void fznHeal(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            if (aTrainer.myBag.myPokemon[aPokeSlot].isFrozen())
            {
                aTrainer.myBag.myPokemon[aPokeSlot].fznHeal();
                aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " melted!");
                aForm.updateData();
            }
            else
                aForm.setTextMessage(myName + " does nothing!");
        }

        protected void slpHeal(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            if (aTrainer.myBag.myPokemon[aPokeSlot].isAsleep())
            {
                aTrainer.myBag.myPokemon[aPokeSlot].slpHeal();
                aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " melted!");
                aForm.updateData();
            }
            else
                aForm.setTextMessage(myName + " does nothing!");
        }

        protected void przHeal(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            if (aTrainer.myBag.myPokemon[aPokeSlot].isParalyzed())
            {
                aTrainer.myBag.myPokemon[aPokeSlot].przHeal();
                aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " melted!");
                aForm.updateData();
            }
            else
                aForm.setTextMessage(myName + " does nothing!");
        }

        protected void cfzHeal(ref Trainer aTrainer, int aPokeSlot, Form1 aForm)
        {
            if (aTrainer.myBag.myPokemon[aPokeSlot].isConfused())
            {
                aTrainer.myBag.myPokemon[aPokeSlot].cfzHeal();
                aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " is no longer confused!");
                aForm.updateData();
            }
            else
                aForm.setTextMessage(myName + " does nothing!");
        }

        protected void raiseAcc(ref Trainer aTrainer, int aPokeSlot, int aStageAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].changeAcc(aStageAmount);
            aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " gets a boost of Accuracy!");
        }

        protected void raiseAtk(ref Trainer aTrainer, int aPokeSlot, int aStageAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].changeAtk(aStageAmount);
            aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " gets a boost of Attack!");
        }

        protected void raiseDef(ref Trainer aTrainer, int aPokeSlot, int aStageAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].changeDef(aStageAmount);
            aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " gets a boost of Defense!");
        }

        protected void raiseSpecA(ref Trainer aTrainer, int aPokeSlot, int aStageAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].changeSpecA(aStageAmount);
            aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " gets a boost of Special Attack!");
        }

        protected void raiseSpecD(ref Trainer aTrainer, int aPokeSlot, int aStageAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].changeSpecD(aStageAmount);
            aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " gets a boost of Special Defense!");
        }

        protected void raiseSpd(ref Trainer aTrainer, int aPokeSlot, int aStageAmount, Form1 aForm)
        {
            aTrainer.myBag.myPokemon[aPokeSlot].changeSpd(aStageAmount);
            aForm.setTextMessage(aTrainer.myBag.myPokemon[aPokeSlot].getName() + " gets a boost of Speed!");
        }
    }
}
