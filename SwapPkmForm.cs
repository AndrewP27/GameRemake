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
    public partial class SwapPkmForm : Form
    {

        int SPRITE_HEIGHT = 80;
        int SPRITE_WIDTH = 80;
        int IMAGE_SCALE = 1;

        public int SlotChoice = -1;
        Trainer thisTrainer;
        bool checkAlive;

        public SwapPkmForm(Trainer aTrainer, bool aCheckAlive)
        {
            InitializeComponent();
            thisTrainer = aTrainer;
            setUpPkmImages();
            setUpPkmProperties();
            checkAlive = aCheckAlive;
        }

        private void setUpPkmProperties()
        {
            Pokemon tempPoke = thisTrainer.myBag.myPokemon[0];
            if (tempPoke != null)
            {
                prb0.Maximum = tempPoke.getMaxHP();
                prb0.Value = (int)Math.Ceiling(tempPoke.getHP());
                lblName0.Text = tempPoke.getName();
                lblHp0.Text = "HP: " + Math.Ceiling(tempPoke.getHP()) + " / " + tempPoke.getMaxHP();
            }
            else
            {
                lblName0.Text = "";
                lblHp0.Text = "";
            }

            tempPoke = thisTrainer.myBag.myPokemon[1];
            if (tempPoke != null)
            {
                prb1.Maximum = tempPoke.getMaxHP();
                prb1.Value = (int)Math.Ceiling(tempPoke.getHP());
                lblName1.Text = tempPoke.getName();
                lblHp1.Text = "HP: " + Math.Ceiling(tempPoke.getHP()) + " / " + tempPoke.getMaxHP();
            }
            else
            {
                lblName1.Text = "";
                lblHp1.Text = "";
            }

            tempPoke = thisTrainer.myBag.myPokemon[2];
            if (tempPoke != null)
            {
                prb2.Maximum = tempPoke.getMaxHP();
                prb2.Value = (int)Math.Ceiling(tempPoke.getHP());
                lblName2.Text = tempPoke.getName();
                lblHp2.Text = "HP: " + Math.Ceiling(tempPoke.getHP()) + " / " + tempPoke.getMaxHP();
            }
            else
            {
                lblName2.Text = "";
                lblHp2.Text = "";
            }

            tempPoke = thisTrainer.myBag.myPokemon[3];
            if (tempPoke != null)
            {
                prb3.Maximum = tempPoke.getMaxHP();
                prb3.Value = (int)Math.Ceiling(tempPoke.getHP());
                lblName3.Text = tempPoke.getName();
                lblHp3.Text = "HP: " + Math.Ceiling(tempPoke.getHP()) + " / " + tempPoke.getMaxHP();
            }
            else
            {
                lblName3.Text = "";
                lblHp3.Text = "";
            }

            tempPoke = thisTrainer.myBag.myPokemon[4];
            if (tempPoke != null)
            {
                prb4.Maximum = tempPoke.getMaxHP();
                prb4.Value = (int)Math.Ceiling(tempPoke.getHP());
                lblName4.Text = tempPoke.getName();
                lblHp4.Text = "HP: " + Math.Ceiling(tempPoke.getHP()) + " / " + tempPoke.getMaxHP();
            }
            else
            {
                lblName4.Text = "";
                lblHp4.Text = "";
            }

            tempPoke = thisTrainer.myBag.myPokemon[5];
            if (tempPoke != null)
            {
                prb5.Maximum = tempPoke.getMaxHP();
                prb5.Value = (int)Math.Ceiling(tempPoke.getHP());
                lblName5.Text = tempPoke.getName();
                lblHp5.Text = "HP: " + Math.Ceiling(tempPoke.getHP()) + " / " + tempPoke.getMaxHP();
            }
            else
            {
                lblName5.Text = "";
                lblHp5.Text = "";
            }
        }


        private void setUpPkmImages()
        {
            pbSlot0.Refresh();
            pbSlot1.Refresh();
            pbSlot2.Refresh();
            pbSlot3.Refresh();
            pbSlot4.Refresh();
            pbSlot5.Refresh();
        }



        private void pbSlot0_Paint(object sender, PaintEventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[0] != null)
            {
                int idNum = thisTrainer.myBag.myPokemon[0].getID();
                if (idNum != -1)
                {
                    int xLoc = Utilities.getXLocation(idNum);
                    int yLoc = Utilities.getYLocation(idNum);
                    e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

                }
            }
        }

        private void pbSlot1_Paint(object sender, PaintEventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[1] != null)
            {
                int idNum = thisTrainer.myBag.myPokemon[1].getID();
                if (idNum != -1)
                {
                    int xLoc = Utilities.getXLocation(idNum);
                    int yLoc = Utilities.getYLocation(idNum);
                    e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

                }
            }
        }

        private void pbSlot2_Paint(object sender, PaintEventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[2] != null)
            {
                int idNum = thisTrainer.myBag.myPokemon[2].getID();
                if (idNum != -1)
                {
                    int xLoc = Utilities.getXLocation(idNum);
                    int yLoc = Utilities.getYLocation(idNum);
                    e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

                }
            }
        }

        private void pbSlot3_Paint(object sender, PaintEventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[3] != null)
            {
                int idNum = thisTrainer.myBag.myPokemon[3].getID();
                if (idNum != -1)
                {
                    int xLoc = Utilities.getXLocation(idNum);
                    int yLoc = Utilities.getYLocation(idNum);
                    e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

                }
            }
        }

        private void pbSlot4_Paint(object sender, PaintEventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[4] != null)
            {
                int idNum = thisTrainer.myBag.myPokemon[4].getID();
                if (idNum != -1)
                {
                    int xLoc = Utilities.getXLocation(idNum);
                    int yLoc = Utilities.getYLocation(idNum);
                    e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

                }
            }
        }

        private void pbSlot5_Paint(object sender, PaintEventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[5] != null)
            {
                int idNum = thisTrainer.myBag.myPokemon[5].getID();
                if (idNum != -1)
                {
                    int xLoc = Utilities.getXLocation(idNum);
                    int yLoc = Utilities.getYLocation(idNum);
                    e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

                }
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[0] != null && (thisTrainer.myBag.myPokemon[0].isAlive() || !checkAlive))
            {
                SlotChoice = 0;
                this.Close();
            }
            else
            {
                MessageBox.Show("This Pokemon is Invalid!");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[1] != null && (thisTrainer.myBag.myPokemon[1].isAlive() || !checkAlive))
            {
                SlotChoice = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show("This Pokemon is Invalid!");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[2] != null && (thisTrainer.myBag.myPokemon[2].isAlive() || !checkAlive))
            {
                SlotChoice = 2;
                this.Close();
            }
            else
            {
                MessageBox.Show("This Pokemon is Invalid!");
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[3] != null && (thisTrainer.myBag.myPokemon[3].isAlive() || !checkAlive))
            {
                SlotChoice = 3;
                this.Close();
            }
            else
            {
                MessageBox.Show("This Pokemon is Invalid!");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[4] != null && (thisTrainer.myBag.myPokemon[4].isAlive() || !checkAlive))
            {
                SlotChoice = 4;
                this.Close();
            }
            else
            {
                MessageBox.Show("This Pokemon is Invalid!");
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (thisTrainer.myBag.myPokemon[5] != null && (thisTrainer.myBag.myPokemon[5].isAlive() || !checkAlive))
            {
                SlotChoice = 5;
                this.Close();
            }
            else
            {
                MessageBox.Show("This Pokemon is Invalid!");
            }
        }
    }
}
