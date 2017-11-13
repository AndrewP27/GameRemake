using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public class ItemManager
    {
        public List<Item> myItems;

        public ItemManager()
        {
            myItems = new List<Item>();
        }

        public List<Item> getMyItems()
        {
            return myItems;
        }

        public void addNewItem(int idNum, int count)
        {
            Item newItem;

            newItem = Utilities.getItemObj(idNum);

            int itemLoc = myItems.FindIndex(
                delegate (Item i)
                {
                    return i.getID() == idNum;
                });

            if(itemLoc == -1)
            {
                newItem.setCount(count);
                myItems.Add(newItem);
            }
            else
            {
                myItems[itemLoc].setCount(myItems[itemLoc].getCount() + count);
            }
        }

        public void useItem(int slotNum, ref Trainer aTrainer, Form1 aForm)
        {
            

            if (! (slotNum >= 0  && slotNum < myItems.Count))
            {
                throw new Exception("Item Does not Exist!");
            }

            myItems[slotNum].preUseItem(ref aTrainer, aForm);
            if (myItems[slotNum].getCount() <= 0)
                myItems.Remove(myItems[slotNum]);
        }
    }
}
