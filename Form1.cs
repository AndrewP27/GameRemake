using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Media;
using System.IO;

namespace PokemonRemake
{
    public partial class Form1 : Form
    {
        public Trainer trainer1;
        public Trainer trainer2;

        int SPRITE_HEIGHT = 80;
        int SPRITE_WIDTH = 80;
        int hpScale = 10;
        int HP_MOVE_AMOUNT = 300;
        int TEXTWAITTIME = 750;
        int TEXTWAITTIMEHP = 250;

        WMPLib.WindowsMediaPlayer soundEffectPlayer = new WMPLib.WindowsMediaPlayer();

        System.Timers.Timer t = new System.Timers.Timer();
        bool wating = false;
        public bool blockChoice = false;

        int IMAGE_SCALE = 3;

        enum DisplayState { mainMenu, TmHm, None};

        DisplayState mState;

        public Form1(Trainer aTrainer1, Trainer aTrainer2)
        {
            InitializeComponent();

           



            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(timerDone);

            lblText.Text = "";
        
            soundEffectPlayer.URL = Utilities.getBasePath() + "Hit.mp3";



            trainer1 = aTrainer1;
            trainer2 = aTrainer2;

            if(trainer1.getPokeSlot(0) != null)
                trainer1.setActivePokemon(0);
            else if (trainer1.getPokeSlot(1) != null)
                trainer1.setActivePokemon(1);
            else if (trainer1.getPokeSlot(2) != null)
                trainer1.setActivePokemon(2);
            else if (trainer1.getPokeSlot(3) != null)
                trainer1.setActivePokemon(3);
            else if (trainer1.getPokeSlot(4) != null)
                trainer1.setActivePokemon(4);
            else if (trainer1.getPokeSlot(5) != null)
                trainer1.setActivePokemon(5);

            if (trainer2.getPokeSlot(0) != null)
                trainer2.setActivePokemon(0);
            else if (trainer2.getPokeSlot(1) != null)
                trainer2.setActivePokemon(1);
            else if (trainer2.getPokeSlot(2) != null)
                trainer2.setActivePokemon(2);
            else if (trainer2.getPokeSlot(3) != null)
                trainer2.setActivePokemon(3);
            else if (trainer2.getPokeSlot(4) != null)
                trainer2.setActivePokemon(4);
            else if (trainer2.getPokeSlot(5) != null)
                trainer2.setActivePokemon(5);

            updateRemainingHP();

            mState = DisplayState.mainMenu;
            updateElements();

            btnBack.Enabled = true;
            btnBack.Left = (this.ClientSize.Width - btnBack.Width) / 2;

            // TEMPORARY CODE!!!!

            trainer1.addNewItem(1, 2);
            trainer1.addNewItem(2, 2);
            trainer1.addNewItem(3, 2);
            trainer1.addNewItem(4, 2);
            trainer1.addNewItem(5, 2);
            trainer1.addNewItem(6, 2);

            /////

        }

        public void setTextMessage(string Text)
        {
            lblText.Text = Text;
            updateElements();
            lblText.Refresh();
            wait(TEXTWAITTIME);
            lblText.Text = "";
        }

        public void setDescMessage(string Text)
        {
            lblText.Text = Text;
            lblText.Refresh();
        }

        public void setDamageMessage(string name, string TmHmName, int aTrainerSlot)
        {
            atkPkm(aTrainerSlot);

            wait(125);

            shakePkm(aTrainerSlot);

            updateHPDamage();

            lblText.Text = "";
            lblText.Refresh();

            wait(250);
        }

        public void setSelfDamageMessage(string name, string TmHmName, int aTrainerSlot)
        {
            shakePkm(aTrainerSlot);

            updateHPDamage();

            lblText.Text = "";
            lblText.Refresh();

            wait(250);
        }

        public void setConfusionMessage(string name)
        {
            lblText.Text = name + " hit themself in confusion";
            lblText.Refresh();

            updateHPDamage();
        }

        public void setPoisionMessage(string name)
        {
            lblText.Text = name + " is hurt by poision";
            lblText.Refresh();

            updateHPDamage();
        }

        public void setBurnedMessage(string name)
        {
            lblText.Text = name + " is hurt by their burns";
            lblText.Refresh();

            updateHPDamage();
        }

        public void healMessage(string aName, string TmHmName)
        {
            int goalHP = (int)Math.Ceiling(trainer1.activePokemon.getHP() * hpScale);


            int hpMove = (int)Math.Ceiling(((double)((goalHP-prbY.Value) * hpScale) / HP_MOVE_AMOUNT));

            if (goalHP != prbY.Value)
            {
                lblText.Text = aName + " healed with " + TmHmName + " !";
                lblText.Refresh();

                // Trainer1
                while (prbY.Value < goalHP)
                {
                    if (prbY.Value + hpMove > prbY.Maximum)
                        prbY.Value = prbY.Maximum;
                    else
                        prbY.Value += hpMove;
                    prbY.Refresh();
                    wait(10);
                }
                wait(100);
                if (prbY.Value != goalHP && goalHP <= prbY.Maximum)
                {
                    prbY.Value = goalHP;
                    prbY.Refresh();
                }
            }
            // Trainer2
            goalHP = (int)Math.Ceiling(trainer2.activePokemon.getHP() * hpScale);

            hpMove = (int)Math.Ceiling(((double)((goalHP - prbR.Value) * hpScale) / HP_MOVE_AMOUNT));

            if (goalHP != prbR.Value)
            {
                lblText.Text = aName + " healed with " + TmHmName + " !";
                lblText.Refresh();

                while (prbR.Value < goalHP)
                {
                    if (prbR.Value + hpMove > prbR.Maximum)
                        prbR.Value = prbR.Maximum;
                    else
                        prbR.Value += hpMove;
                    prbR.Refresh();
                    wait(10);
                }
                wait(100);
                if (prbR.Value != goalHP && goalHP <= prbR.Maximum)
                {
                    prbR.Value = goalHP;
                    prbR.Refresh();
                }

                prbR.Refresh();
            }

            wait(TEXTWAITTIMEHP);

            updateElements();
            lblText.Text = "";
        }


        public void updateElements()
        {
            updateBtns();
            pbRPok.Refresh();
            pbYPok.Refresh();
            updateData();
            //setDescMessage("");
        }


        public void updateHPDamage()
        {
            // Trainer1
            int goalHP = (int) (Math.Ceiling(trainer1.activePokemon.getHP()) * hpScale);

            int hpMove =  (int)Math.Ceiling(((double)((prbY.Value - goalHP) * hpScale) / HP_MOVE_AMOUNT));

            while (prbY.Value > goalHP)
            {
                if (prbY.Value - hpMove < 0)
                    prbY.Value = 0;
                else
                    prbY.Value -= hpMove;
                wait(5);
                prbY.Refresh();
            }

            wait(100);
            if (prbY.Value != goalHP * hpScale && goalHP <= prbY.Maximum)
                prbY.Value = goalHP;

            // Trainer2
            goalHP = (int) (Math.Ceiling(trainer2.activePokemon.getHP()) * hpScale);

            hpMove = (int)Math.Ceiling(((double)((prbR.Value - goalHP) * hpScale) / HP_MOVE_AMOUNT));

            while (prbR.Value > goalHP)
            {
                if (prbR.Value - hpMove < 0)
                    prbR.Value = 0;
                else
                    prbR.Value -= hpMove;
                wait(5);
                prbR.Refresh();
            }

            wait(100);
            if (prbR.Value != goalHP * hpScale && goalHP <= prbR.Maximum)
                prbR.Value = goalHP;

            prbR.Refresh();

            wait(TEXTWAITTIMEHP);

            updateElements();
            lblText.Text = "";
        }
        private void updateRemainingHP()
        {
            prbR.Maximum = trainer2.activePokemon.getMaxHP() * hpScale;
            prbR.Value = (int)Math.Ceiling(trainer2.activePokemon.getHP()) * hpScale;
            prbR.Refresh();
            prbY.Maximum = trainer1.activePokemon.getMaxHP() * hpScale;
            prbY.Value = (int)Math.Ceiling(trainer1.activePokemon.getHP()) * hpScale;
            prbY.Refresh();
        }

        public void updateData()
        {
            // TRAINER 1
            prbY.Maximum = trainer1.activePokemon.getMaxHP() * hpScale;
            prbY.Value = (int)Math.Ceiling(trainer1.activePokemon.getHP() * hpScale);
            prbY.Refresh();
            lblYHP.Text = (((int)Math.Ceiling(trainer1.activePokemon.getHP())).ToString() + " / " + trainer1.activePokemon.getMaxHP().ToString());
            lblYHP.Refresh();
            lblYLv.Text = "LV: " +  trainer1.activePokemon.getLevel().ToString();
            lblYLv.Refresh();
            lblYName.Text = trainer1.activePokemon.getName();
            lblYName.Refresh();



            //WIP
            lblYStat.Text = trainer1.activePokemon.getStatusText();
            lblYStat.Refresh();

            // TRAINER 2
            prbR.Maximum = trainer2.activePokemon.getMaxHP() * hpScale;
            prbR.Value = (int)Math.Ceiling(trainer2.activePokemon.getHP() * hpScale);
            prbR.Refresh();
            lblRHP.Text = (((int)Math.Ceiling(trainer2.activePokemon.getHP())).ToString() + " / " + trainer2.activePokemon.getMaxHP().ToString());
            lblRHP.Refresh();
            lblRLv.Text = "LV: " + trainer2.activePokemon.getLevel().ToString();
            lblRLv.Refresh();
            lblRName.Text = trainer2.activePokemon.getName();
            lblRName.Refresh();

            //WIP
            lblRStat.Text = trainer2.activePokemon.getStatusText();
            lblRStat.Refresh();
        }

        private void updateBtns()
        {
            switch (mState)
            {
                case DisplayState.mainMenu:
                    

                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    btn4.Visible = true;
                    btn1.Text = "Fight";
                    btn2.Text = "Pokemon";
                    btn3.Text = "Items";
                    btn4.Text = "Run";
                    btnBack.Visible = false;
                    btnBack.Enabled = false;

                    btn1.Enabled = true;
                    btn1.Left = (this.ClientSize.Width - btn1.Width) / 2;

                    btn2.Enabled = true;
                    btn2.Left = (this.ClientSize.Width - btn2.Width) / 2;

                    btn3.Enabled = true;
                    btn3.Left = (this.ClientSize.Width - btn3.Width) / 2;

                    btn4.Enabled = true;
                    btn4.Left = (this.ClientSize.Width - btn4.Width) / 2;

                    break;
                case DisplayState.TmHm:
                    

                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    btn4.Visible = true;
                    btnBack.Visible = true;
                    btnBack.Enabled = true;
                    btn1.Text = trainer1.activePokemon.getMoveName(0);
                    btn2.Text = trainer1.activePokemon.getMoveName(1);
                    btn3.Text = trainer1.activePokemon.getMoveName(2);
                    btn4.Text = trainer1.activePokemon.getMoveName(3);

                    btn1.Enabled = true;
                    btn1.Left = (this.ClientSize.Width - btn1.Width) / 2;

                    btn2.Enabled = true;
                    btn2.Left = (this.ClientSize.Width - btn2.Width) / 2;

                    btn3.Enabled = true;
                    btn3.Left = (this.ClientSize.Width - btn3.Width) / 2;

                    btn4.Enabled = true;
                    btn4.Left = (this.ClientSize.Width - btn4.Width) / 2;
                    break;
                case DisplayState.None:
                    btn1.Enabled = false;
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                    btn4.Enabled = false;
                    btn1.Visible = false;
                    btn2.Visible = false;
                    btn3.Visible = false;
                    btn4.Visible = false;
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        
        private void tmrTxt_Tick(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mState = DisplayState.mainMenu;
            updateElements();
        }
        

        private void enterBattleManagerAttack(ref Trainer trainer1, ref Trainer trainer2, int moveChoiceNum)
        {
            mState = DisplayState.None;
            updateElements();
            BattleManager.choseMove(moveChoiceNum, ref trainer1, ref trainer2, this);
            if (blockChoice)
                enterBattleManagerAttack(ref trainer1, ref trainer2, moveChoiceNum);
            mState = DisplayState.mainMenu;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            switch (mState)
            {
                case DisplayState.mainMenu:
                    if (!trainer1.askPersistant())
                    {
                        if (trainer1.activePokemon.askValidTmHmNum().Count == 0)
                        {
                            mState = DisplayState.None;
                            updateElements();
                            BattleManager.struggle(ref trainer1, ref trainer2, this);
                            mState = DisplayState.mainMenu;
                        }
                        else
                            mState = DisplayState.TmHm;
                    }
                    else
                        if (trainer1.activePokemon.getMove(0) != null)
                            enterBattleManagerAttack(ref trainer1, ref trainer2, 0);
                        else
                            MessageBox.Show("Pick a Valid Move!");
                    break;
                case DisplayState.TmHm:
                    enterBattleManagerAttack(ref trainer1, ref trainer2, 0);
                    break;
                case DisplayState.None:
                    break;
                default:
                    break;
            }
            updateElements();


        }

        private void btn2_Click(object sender, EventArgs e)
        {
            switch (mState)
            {
                case DisplayState.mainMenu:
                    mState = DisplayState.None;
                    updateElements();

                    SwapPkmForm swapping = new SwapPkmForm(trainer1, true);
                    swapping.ShowDialog();

                    int newSlot = swapping.SlotChoice;

                    BattleManager.choseSwitch(newSlot, ref trainer1, ref trainer2, this);
                    mState = DisplayState.mainMenu;
                    break;
                case DisplayState.TmHm:
                    if (trainer1.activePokemon.getMove(1) != null)
                        enterBattleManagerAttack(ref trainer1, ref trainer2, 1);
                    else
                        MessageBox.Show("Pick a Valid Move!");
                    break;
                case DisplayState.None:
                    break;
                default:
                    break;
            }
            updateElements();
        }
        

        private void btn3_Click(object sender, EventArgs e)
        {
            switch (mState)
            {
                case DisplayState.mainMenu:
                    mState = DisplayState.None;
                    updateElements();

                    ItemSelection itemSelect = new ItemSelection(ref trainer1);
                    itemSelect.ShowDialog();

                    int itemSlot = itemSelect.itemSlotNum;

                    if (itemSlot != -1)
                    {
                        BattleManager.choseItem(itemSlot,ref trainer1, ref trainer2, this);
                    }
                    mState = DisplayState.mainMenu;

                    break;
                case DisplayState.TmHm:
                    if (trainer1.activePokemon.getMove(2) != null)
                        enterBattleManagerAttack(ref trainer1, ref trainer2,2);
                    else
                        MessageBox.Show("Pick a Valid Move!");
                    break;
                case DisplayState.None:
                    break;
                default:
                    break;
            }
            updateElements();
        }
        
        private void btn4_Click(object sender, EventArgs e)
        {
            switch (mState)
            {
                case DisplayState.mainMenu:
                    break;
                case DisplayState.TmHm:
                    if (trainer1.activePokemon.getMove(3) != null)
                        enterBattleManagerAttack(ref trainer1, ref trainer2, 3);
                    else
                        MessageBox.Show("Pick a Valid Move!");
                    break;
                case DisplayState.None:
                    break;
                default:
                    break;
            }
            updateElements();
        }

        private void pbYPok_Paint(object sender, PaintEventArgs e)
        {
            int xLoc = Utilities.getXLocation(trainer1.activePokemon.getID());
            int yLoc = Utilities.getYLocation(trainer1.activePokemon.getID());
            e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc *SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);
        }

        private void pbRPok_Paint(object sender, PaintEventArgs e)
        {
            int xLoc = Utilities.getXLocation(trainer2.activePokemon.getID());
            int yLoc = Utilities.getYLocation(trainer2.activePokemon.getID());
            e.Graphics.DrawImage(Image.FromFile(Utilities.getBasePath() + "all-pokemon.png"), -xLoc * SPRITE_WIDTH * IMAGE_SCALE, -yLoc * SPRITE_HEIGHT * IMAGE_SCALE, 2000 * IMAGE_SCALE, 1600 * IMAGE_SCALE);
        }

        void wait(int numMilli)
        {
            t.Interval = numMilli;
            
            wating = true;
            t.Start();
            while(wating)
            {

            }
            t.Stop();
        }

        void timerDone(object sender, ElapsedEventArgs e)
        {
            wating = false;
        }

        public void endBattle()
        {
            Close();
        }


        public void shakePkm(int trainerNum)
        {
            int SHAKENUM = 6;
            int PUSHES = 4;
            int DISTANCE = 3;
            int WAIT_TIME = 4;

            if(trainerNum == 1)
            {
                for (int i = 0; i < SHAKENUM; i++)
                {
                    for (int j = 0; j < PUSHES; j++)
                    {
                        pbYPok.Location = new Point(pbYPok.Location.X + DISTANCE, pbYPok.Location.Y);
                        wait(WAIT_TIME);
                    }

                    for (int j = 0; j < PUSHES; j++)
                    {
                        pbYPok.Location = new Point(pbYPok.Location.X - DISTANCE, pbYPok.Location.Y);
                        wait(WAIT_TIME);
                    }
                }
            }
            else if(trainerNum == 2)
            {
                for (int i = 0; i < SHAKENUM; i++)
                {
                    for (int j = 0; j < PUSHES; j++)
                    {
                        pbRPok.Location = new Point(pbRPok.Location.X + DISTANCE, pbRPok.Location.Y);
                        wait(WAIT_TIME);
                    }

                    for (int j = 0; j < PUSHES; j++)
                    {
                        pbRPok.Location = new Point(pbRPok.Location.X - DISTANCE, pbRPok.Location.Y);
                        wait(WAIT_TIME);
                    }
                }
            }
        }

        public void atkPkm(int trainerNum)
        {

            int PUSHES = 4;
            int DISTANCE = 10;
            int WAIT_TIME = 4;

            if (trainerNum == 2)
            {
                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X + DISTANCE, pbYPok.Location.Y);
                    wait(WAIT_TIME);
                }

                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X - DISTANCE, pbYPok.Location.Y);
                    wait(WAIT_TIME);
                }
            }
            else if (trainerNum == 1)
            {
                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X - DISTANCE, pbRPok.Location.Y);
                    wait(WAIT_TIME);
                }

                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X + DISTANCE, pbRPok.Location.Y);
                    wait(WAIT_TIME);
                }
            }
        }

        public void onDeath(int trainerNum)
        {
            int PUSHES = 5;
            int DISTANCE = 6;
            int WAIT_TIME = 2;

            if (trainerNum == 1)
            {
                Point Saved = pbYPok.Location;
                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y + DISTANCE);
                    wait(WAIT_TIME);
                }

                pbYPok.Visible = false;
                pbYPok.Location = Saved;
            }
            else if (trainerNum == 2)
            {
                Point Saved = pbRPok.Location;
                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y + DISTANCE);
                    wait(WAIT_TIME);
                }

                pbRPok.Visible = false;
                pbRPok.Location = Saved;
            }
        }

        public void powerUp(int trainerNum)
        {
            int PUSHES = 5;
            int DISTANCE = 5;
            int WAIT_TIME = 16;
            int NUM_JUMPS = 2;

            if (trainerNum == 1)
            {
                for (int j = 0; j < NUM_JUMPS; j++)
                {
                    for (int i = 0; i < PUSHES; i++)
                    {
                        pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y - DISTANCE);
                        wait(WAIT_TIME);
                    }

                    for (int i = 0; i < PUSHES; i++)
                    {
                        pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y + DISTANCE);
                        wait(WAIT_TIME);
                    }
                }
            }
            else if (trainerNum == 2)
            {
                for (int j = 0; j < NUM_JUMPS; j++)
                {
                    for (int i = 0; i < PUSHES; i++)
                    {
                        pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y - DISTANCE);
                        wait(WAIT_TIME);
                    }
                    for (int i = 0; i < PUSHES; i++)
                    {
                        pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y + DISTANCE);
                        wait(WAIT_TIME);
                    }
                }
            }
        }
        public void ResetPics()
        {
            pbYPok.Visible = true;
            pbRPok.Visible = true;

        }

        public void burySprite(int trainerNum)
        {
            int PUSHES = 5;
            int DISTANCE = 6;
            int WAIT_TIME = 10;

            if (trainerNum == 1)
            {
                Point Saved = pbYPok.Location;
                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y + DISTANCE);
                    wait(WAIT_TIME);
                }

                pbYPok.Visible = false;
                pbYPok.Location = Saved;
            }
            else if (trainerNum == 2)
            {
                Point Saved = pbRPok.Location;
                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y + DISTANCE);
                    wait(WAIT_TIME);
                }

                pbRPok.Visible = false;
                pbRPok.Location = Saved;
            }
        }

        public void digUpSprite(int trainerNum)
        {
            int PUSHES = 5;
            int DISTANCE = 6;
            int WAIT_TIME = 10;

            if (trainerNum == 1)
            {
                pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y + DISTANCE * PUSHES);
                pbYPok.Visible = true;
                pbYPok.Refresh();
                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y - DISTANCE);
                    wait(WAIT_TIME);
                }

                
            }
            else if (trainerNum == 2)
            {
                pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y + DISTANCE * PUSHES);
                pbRPok.Visible = true;
                pbRPok.Refresh();
                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y - DISTANCE);
                    wait(WAIT_TIME);
                }

                
            }
        }

        public void FlySprite(int trainerNum)
        {
            int PUSHES = 5;
            int DISTANCE = 6;
            int WAIT_TIME = 10;

            if (trainerNum == 1)
            {
                Point Saved = pbYPok.Location;
                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y - DISTANCE);
                    wait(WAIT_TIME);
                }

                pbYPok.Visible = false;
                pbYPok.Location = Saved;
            }
            else if (trainerNum == 2)
            {
                Point Saved = pbRPok.Location;
                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y - DISTANCE);
                    wait(WAIT_TIME);
                }

                pbRPok.Visible = false;
                pbRPok.Location = Saved;
            }
        }

        public void FlyDownSprite(int trainerNum)
        {
            int PUSHES = 5;
            int DISTANCE = 6;
            int WAIT_TIME = 10;

            if (trainerNum == 1)
            {
                pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y - DISTANCE * PUSHES);
                pbYPok.Visible = true;
                pbYPok.Refresh();
                for (int i = 0; i < PUSHES; i++)
                {
                    pbYPok.Location = new Point(pbYPok.Location.X, pbYPok.Location.Y + DISTANCE);
                    wait(WAIT_TIME);
                }


            }
            else if (trainerNum == 2)
            {
                pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y - DISTANCE * PUSHES);
                pbRPok.Visible = true;
                pbRPok.Refresh();
                for (int i = 0; i < PUSHES; i++)
                {
                    pbRPok.Location = new Point(pbRPok.Location.X, pbRPok.Location.Y + DISTANCE);
                    wait(WAIT_TIME);
                }


            }
        }

        private void btn1_MouseEnter(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage(trainer1.getTmHmString(0));
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage("");
        }

        private void btn4_MouseEnter(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage(trainer1.getTmHmString(3));
        }

        private void btn4_MouseLeave(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage("");
        }

        private void btn3_MouseEnter(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage(trainer1.getTmHmString(2));
        }

        private void btn3_MouseLeave(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage("");
        }

        private void btn2_MouseEnter(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage(trainer1.getTmHmString(1));
        }

        private void btn2_MouseLeave(object sender, EventArgs e)
        {
            if (mState == DisplayState.TmHm)
                setDescMessage("");
        }

        public void ForceNewPkm(int trainerSlot)
        {
            if(trainerSlot == 1)
            {
                bool isDone = false;
                int oldPokemonSlot = trainer1.askPreviousSlot();

                int newSlot = 0;

                while (!isDone)
                {
                    SwapPkmForm swapping = new SwapPkmForm(trainer1, true);
                    swapping.ShowDialog();

                    newSlot = swapping.SlotChoice;

                    if (newSlot != oldPokemonSlot)
                        isDone = true;
                    else
                        MessageBox.Show("You need to pick a NEW pokemon!");
                }

                trainer1.setActivePokemon(newSlot);

            }
            if (trainerSlot == 2)
            {
                trainer2.PromptAINextPkmBanned(ref trainer1, ref trainer2,trainer2.askPreviousSlot());
            }
        }
    }
    
}
