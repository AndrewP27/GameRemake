using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonRemake
{
    public partial class ItemSelection : Form
    {
        private List<Item> itemSet;
        public int itemSlotNum = -1;

        public ItemSelection(ref Trainer aTrainer)
        {
            InitializeComponent();
            
            itemSet = aTrainer.getMyItems();
            setUpComboBox(ref aTrainer);

        }

        private void setUpComboBox(ref Trainer aTrainer)
        {

            foreach (Item i in itemSet)
            {
                cbItems.Items.Add(i.getName() + " : " + i.getCount());
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbItems.SelectedItem == null)
            {
                Close();
            }
            else
            {
                string Choice = cbItems.SelectedItem.ToString();
                int itemNum = cbItems.Items.IndexOf(Choice);
                if (itemSet[itemNum].askUseInBattle())
                {
                    itemSlotNum = itemNum;
                    Close();
                }
                else
                    MessageBox.Show("OAK: This isn't the time to use that!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbItems.SelectedItem == null)
                return;
            string Choice = cbItems.SelectedItem.ToString();
            int itemNum = cbItems.Items.IndexOf(Choice);

            lbItemDesc.Text = itemSet[itemNum].getDescription();
        }
    }
}
