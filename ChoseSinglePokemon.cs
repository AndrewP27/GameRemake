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
    public partial class ChoseSinglePokemon : Form
    {
        public Pokemon chosenPokemon = null;
        private int trainerSlot;

        public ChoseSinglePokemon(int aTrainerSlot)
        {
            InitializeComponent();

            trainerSlot = aTrainerSlot;

            for (int i = 1; i < UtilitiesPkmTable.getMaxLineNum(); i++)
            {
                cbPoke.Items.Add(UtilitiesPkmTable.getPkmName(i));
            }

            for (int i = 1; i < UtilitiesTmTable.getMaxLineNum(); i++)
            {
                cbMove0.Items.Add(UtilitiesTmTable.getTmName(i));
                cbMove1.Items.Add(UtilitiesTmTable.getTmName(i));
                cbMove2.Items.Add(UtilitiesTmTable.getTmName(i));
                cbMove3.Items.Add(UtilitiesTmTable.getTmName(i));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pokeNum;
            int lv;
            int TmHm0 = -1;
            int TmHm1 = -1;
            int TmHm2 = -1;
            int TmHm3 = -1;

            object choiceVal = cbPoke.SelectedItem;
            string Choice;
            if (choiceVal != null)
            {
                Choice = choiceVal.ToString();
                pokeNum = cbPoke.Items.IndexOf(Choice);

                lv = (int)numLv.Value;
                if (lv > 0)
                {

                    choiceVal = cbMove0.SelectedItem;
                    if (choiceVal != null)
                    {
                        Choice = choiceVal.ToString();
                        TmHm0 = cbMove0.Items.IndexOf(Choice);

                        choiceVal = cbMove1.SelectedItem;
                        if (choiceVal != null)
                        {
                            Choice = choiceVal.ToString();
                            TmHm1 = cbMove1.Items.IndexOf(Choice);
                        }

                        choiceVal = cbMove2.SelectedItem;
                        if (choiceVal != null)
                        {
                            Choice = choiceVal.ToString();
                            TmHm2 = cbMove2.Items.IndexOf(Choice);
                        }

                        choiceVal = cbMove3.SelectedItem;
                        if (choiceVal != null)
                        {
                            Choice = choiceVal.ToString();
                            TmHm3 = cbMove3.Items.IndexOf(Choice);
                        }

                        // Create Pokemon

                        chosenPokemon = new Pokemon(pokeNum+1, lv, trainerSlot);

                        chosenPokemon.setNewMove(TmHm0+1, 0);
                        if(TmHm1 != -1)
                            chosenPokemon.setNewMove(TmHm1+1, 1);
                        if (TmHm2 != -1)
                            chosenPokemon.setNewMove(TmHm2+1, 2);
                        if (TmHm3 != -1)
                            chosenPokemon.setNewMove(TmHm3+1, 3);

                        Close();
                    }
                    else
                        MessageBox.Show("You need to select at least one TmHm Type");
                }
                else
                    MessageBox.Show("You need to select a valid Level");
            }
            else
                MessageBox.Show("You need to select a Pokemon Type");
        }
    }
}
