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
    public partial class ChoseFight : Form
    {
        public Trainer trainer1;
        public Trainer trainer2;

        int SPRITE_HEIGHT = 80;
        int SPRITE_WIDTH = 80;
        int IMAGE_SCALE = 1;

        public ChoseFight()
        {
            InitializeComponent();
            trainer1 = new Trainer("Ash", 1);
            trainer2 = new Trainer("Gary", 2);
            setUpPkmText();
        }

        private void setUpPkmImages()
        {
            pbSlot00.Refresh();
            pbSlot10.Refresh();
            pbSlot20.Refresh();
            pbSlot30.Refresh();
            pbSlot40.Refresh();
            pbSlot50.Refresh();

            pbSlot01.Refresh();
            pbSlot11.Refresh();
            pbSlot21.Refresh();
            pbSlot31.Refresh();
            pbSlot41.Refresh();
            pbSlot51.Refresh();
        }

        private string createString(int trainerNum, int bagSlot)
        {
            Pokemon thisPoke;
            if (trainerNum == 0)
                thisPoke = trainer1.getPokeSlot(bagSlot);
            else
                thisPoke = trainer2.getPokeSlot(bagSlot);

            if (thisPoke == null)
                return "";

            return thisPoke.getName() + "   Lv: " + thisPoke.getLevel();
        }

        private void setUpPkmText()
        {
            lblName00.Text = createString(0, 0);
            lblName10.Text = createString(0, 1);
            lblName20.Text = createString(0, 2);
            lblName30.Text = createString(0, 3);
            lblName40.Text = createString(0, 4);
            lblName50.Text = createString(0, 5);

            lblName01.Text = createString(1, 0);
            lblName11.Text = createString(1, 1);
            lblName21.Text = createString(1, 2);
            lblName31.Text = createString(1, 3);
            lblName41.Text = createString(1, 4);
            lblName51.Text = createString(1, 5);
        }

        

        private void makeChoice(int trainerNum, int slotNum)
        {
            ChoseSinglePokemon choice = new ChoseSinglePokemon(trainerNum);
            choice.ShowDialog();

            if (choice.chosenPokemon != null)
            {
                if (trainerNum == 1)
                    trainer1.setPokeSlot(choice.chosenPokemon, slotNum);
                else
                    trainer2.setPokeSlot(choice.chosenPokemon, slotNum);
            }
        }

        private void paint(int trainerNum, int bagSlot, PaintEventArgs e)
        {
            int idNum = -1;
            if (trainerNum == 1)
            {
                if (trainer1.myBag.myPokemon[bagSlot] != null)
                    idNum = trainer1.myBag.myPokemon[bagSlot].getID();
            }
            else
            {
                if (trainer2.myBag.myPokemon[bagSlot] != null)
                    idNum = trainer2.myBag.myPokemon[bagSlot].getID();
            }

            if (idNum != -1)
            {
                int xLoc = Utilities.getXLocation(idNum);
                int yLoc = Utilities.getYLocation(idNum);
                e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);

            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            makeChoice(1, 0);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            makeChoice(1, 1);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            makeChoice(1, 2);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            makeChoice(1, 3);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            makeChoice(1, 4);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            makeChoice(1, 5);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            makeChoice(2, 0);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            makeChoice(2, 1);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            makeChoice(2, 2);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            makeChoice(2, 3);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn41_Click(object sender, EventArgs e)
        { 
            makeChoice(2, 4);
            setUpPkmImages();
            setUpPkmText();
        }

        private void btn51_Click(object sender, EventArgs e)
        {
            makeChoice(2, 5);
            setUpPkmImages();
            setUpPkmText();
        }

        private void pbSlot00_Paint(object sender, PaintEventArgs e)
        {
            paint(1, 0, e);
        }

        private void pbSlot10_Paint(object sender, PaintEventArgs e)
        {
            paint(1, 1, e);
        }

        private void pbSlot20_Paint(object sender, PaintEventArgs e)
        {
            paint(1, 2, e);
        }

        private void pbSlot30_Paint(object sender, PaintEventArgs e)
        {
            paint(1, 3, e);
        }

        private void pbSlot40_Paint(object sender, PaintEventArgs e)
        {
            paint(1, 4, e);
        }

        private void pbSlot50_Paint(object sender, PaintEventArgs e)
        {
            paint(1, 5, e);
        }

        private void pbSlot01_Paint(object sender, PaintEventArgs e)
        {
            paint(2, 0, e);
        }

        private void pbSlot11_Paint(object sender, PaintEventArgs e)
        {
            paint(2, 1, e);
        }

        private void pbSlot21_Paint(object sender, PaintEventArgs e)
        {
            paint(2, 2, e);
        }

        private void pbSlot31_Paint(object sender, PaintEventArgs e)
        {
            paint(2, 3, e);
        }

        private void pbSlot41_Paint(object sender, PaintEventArgs e)
        {
            paint(2, 4, e);
        }

        private void pbSlot51_Paint(object sender, PaintEventArgs e)
        {
            paint(2, 5, e);
        }
    }
}
