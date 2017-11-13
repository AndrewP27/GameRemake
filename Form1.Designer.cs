using System;

namespace PokemonRemake
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn1 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.lblYName = new System.Windows.Forms.Label();
            this.lblYHP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblYStat = new System.Windows.Forms.Label();
            this.lblRStat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRHP = new System.Windows.Forms.Label();
            this.lblRName = new System.Windows.Forms.Label();
            this.prbY = new System.Windows.Forms.ProgressBar();
            this.prbR = new System.Windows.Forms.ProgressBar();
            this.lblRLv = new System.Windows.Forms.Label();
            this.lblYLv = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.pbYPok = new System.Windows.Forms.PictureBox();
            this.pbRPok = new System.Windows.Forms.PictureBox();
            this.tmrTxt = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pbYPok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRPok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn1.AutoSize = true;
            this.btn1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn1.Location = new System.Drawing.Point(332, 161);
            this.btn1.Margin = new System.Windows.Forms.Padding(2);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(55, 30);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "Fight";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            this.btn1.MouseEnter += new System.EventHandler(this.btn1_MouseEnter);
            this.btn1.MouseLeave += new System.EventHandler(this.btn1_MouseLeave);
            // 
            // btn4
            // 
            this.btn4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn4.AutoSize = true;
            this.btn4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn4.Location = new System.Drawing.Point(335, 286);
            this.btn4.Margin = new System.Windows.Forms.Padding(2);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(49, 30);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "Run";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            this.btn4.MouseEnter += new System.EventHandler(this.btn4_MouseEnter);
            this.btn4.MouseLeave += new System.EventHandler(this.btn4_MouseLeave);
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2.AutoSize = true;
            this.btn2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn2.Location = new System.Drawing.Point(316, 202);
            this.btn2.Margin = new System.Windows.Forms.Padding(2);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(86, 30);
            this.btn2.TabIndex = 4;
            this.btn2.Text = "Pokemon";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            this.btn2.MouseEnter += new System.EventHandler(this.btn2_MouseEnter);
            this.btn2.MouseLeave += new System.EventHandler(this.btn2_MouseLeave);
            // 
            // btn3
            // 
            this.btn3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn3.AutoSize = true;
            this.btn3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn3.Location = new System.Drawing.Point(330, 245);
            this.btn3.Margin = new System.Windows.Forms.Padding(2);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(59, 30);
            this.btn3.TabIndex = 5;
            this.btn3.Text = "Items";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            this.btn3.MouseEnter += new System.EventHandler(this.btn3_MouseEnter);
            this.btn3.MouseLeave += new System.EventHandler(this.btn3_MouseLeave);
            // 
            // lblYName
            // 
            this.lblYName.AutoSize = true;
            this.lblYName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYName.Location = new System.Drawing.Point(40, 249);
            this.lblYName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYName.Name = "lblYName";
            this.lblYName.Size = new System.Drawing.Size(51, 20);
            this.lblYName.TabIndex = 6;
            this.lblYName.Text = "Name";
            // 
            // lblYHP
            // 
            this.lblYHP.AutoSize = true;
            this.lblYHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYHP.Location = new System.Drawing.Point(88, 281);
            this.lblYHP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYHP.Name = "lblYHP";
            this.lblYHP.Size = new System.Drawing.Size(31, 20);
            this.lblYHP.TabIndex = 7;
            this.lblYHP.Text = "HP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 281);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hp:";
            // 
            // lblYStat
            // 
            this.lblYStat.AutoSize = true;
            this.lblYStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYStat.Location = new System.Drawing.Point(77, 328);
            this.lblYStat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYStat.Name = "lblYStat";
            this.lblYStat.Size = new System.Drawing.Size(56, 20);
            this.lblYStat.TabIndex = 9;
            this.lblYStat.Text = "Status";
            // 
            // lblRStat
            // 
            this.lblRStat.AutoSize = true;
            this.lblRStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRStat.Location = new System.Drawing.Point(611, 92);
            this.lblRStat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRStat.Name = "lblRStat";
            this.lblRStat.Size = new System.Drawing.Size(56, 20);
            this.lblRStat.TabIndex = 13;
            this.lblRStat.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(574, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Hp:";
            // 
            // lblRHP
            // 
            this.lblRHP.AutoSize = true;
            this.lblRHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRHP.Location = new System.Drawing.Point(622, 48);
            this.lblRHP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRHP.Name = "lblRHP";
            this.lblRHP.Size = new System.Drawing.Size(31, 20);
            this.lblRHP.TabIndex = 11;
            this.lblRHP.Text = "HP";
            // 
            // lblRName
            // 
            this.lblRName.AutoSize = true;
            this.lblRName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRName.Location = new System.Drawing.Point(573, 15);
            this.lblRName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRName.Name = "lblRName";
            this.lblRName.Size = new System.Drawing.Size(51, 20);
            this.lblRName.TabIndex = 10;
            this.lblRName.Text = "Name";
            // 
            // prbY
            // 
            this.prbY.Location = new System.Drawing.Point(44, 308);
            this.prbY.Margin = new System.Windows.Forms.Padding(2);
            this.prbY.Name = "prbY";
            this.prbY.Size = new System.Drawing.Size(118, 19);
            this.prbY.TabIndex = 14;
            this.prbY.Value = 100;
            // 
            // prbR
            // 
            this.prbR.Location = new System.Drawing.Point(578, 71);
            this.prbR.Margin = new System.Windows.Forms.Padding(2);
            this.prbR.Name = "prbR";
            this.prbR.Size = new System.Drawing.Size(118, 19);
            this.prbR.TabIndex = 15;
            this.prbR.Value = 100;
            // 
            // lblRLv
            // 
            this.lblRLv.AutoSize = true;
            this.lblRLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRLv.Location = new System.Drawing.Point(661, 15);
            this.lblRLv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRLv.Name = "lblRLv";
            this.lblRLv.Size = new System.Drawing.Size(29, 20);
            this.lblRLv.TabIndex = 16;
            this.lblRLv.Text = "Lv:";
            // 
            // lblYLv
            // 
            this.lblYLv.AutoSize = true;
            this.lblYLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYLv.Location = new System.Drawing.Point(126, 249);
            this.lblYLv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYLv.Name = "lblYLv";
            this.lblYLv.Size = new System.Drawing.Size(29, 20);
            this.lblYLv.TabIndex = 17;
            this.lblYLv.Text = "Lv:";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.AutoSize = true;
            this.btnBack.Enabled = false;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.Location = new System.Drawing.Point(331, 332);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 30);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.SystemColors.Window;
            this.lblText.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(244, 7);
            this.lblText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(238, 151);
            this.lblText.TabIndex = 21;
            this.lblText.Text = "WORDS";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(494, 144);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 22;
            // 
            // pbYPok
            // 
            this.pbYPok.InitialImage = null;
            this.pbYPok.Location = new System.Drawing.Point(11, 11);
            this.pbYPok.Margin = new System.Windows.Forms.Padding(2);
            this.pbYPok.Name = "pbYPok";
            this.pbYPok.Size = new System.Drawing.Size(240, 240);
            this.pbYPok.TabIndex = 19;
            this.pbYPok.TabStop = false;
            this.pbYPok.Paint += new System.Windows.Forms.PaintEventHandler(this.pbYPok_Paint);
            // 
            // pbRPok
            // 
            this.pbRPok.InitialImage = null;
            this.pbRPok.Location = new System.Drawing.Point(485, 117);
            this.pbRPok.Margin = new System.Windows.Forms.Padding(2);
            this.pbRPok.Name = "pbRPok";
            this.pbRPok.Size = new System.Drawing.Size(240, 240);
            this.pbRPok.TabIndex = 18;
            this.pbRPok.TabStop = false;
            this.pbRPok.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRPok_Paint);
            // 
            // tmrTxt
            // 
            this.tmrTxt.Enabled = true;
            this.tmrTxt.Interval = 10;
            this.tmrTxt.Tick += new System.EventHandler(this.tmrTxt_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(176, 339);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(736, 368);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblYLv);
            this.Controls.Add(this.lblRLv);
            this.Controls.Add(this.prbR);
            this.Controls.Add(this.prbY);
            this.Controls.Add(this.lblRStat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRHP);
            this.Controls.Add(this.lblRName);
            this.Controls.Add(this.lblYStat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblYHP);
            this.Controls.Add(this.lblYName);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.pbYPok);
            this.Controls.Add(this.pbRPok);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbYPok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRPok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Label lblYName;
        private System.Windows.Forms.Label lblYHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblYStat;
        private System.Windows.Forms.Label lblRStat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRHP;
        private System.Windows.Forms.Label lblRName;
        private System.Windows.Forms.ProgressBar prbY;
        private System.Windows.Forms.ProgressBar prbR;
        private System.Windows.Forms.Label lblRLv;
        private System.Windows.Forms.Label lblYLv;
        private System.Windows.Forms.PictureBox pbRPok;
        private System.Windows.Forms.PictureBox pbYPok;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Timer tmrTxt;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

