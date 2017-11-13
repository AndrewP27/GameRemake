namespace PokemonRemake
{
    partial class ChoseSinglePokemon
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
            this.cbPoke = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMove0 = new System.Windows.Forms.ComboBox();
            this.cbMove1 = new System.Windows.Forms.ComboBox();
            this.cbMove2 = new System.Windows.Forms.ComboBox();
            this.cbMove3 = new System.Windows.Forms.ComboBox();
            this.numLv = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLv)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPoke
            // 
            this.cbPoke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPoke.FormattingEnabled = true;
            this.cbPoke.Location = new System.Drawing.Point(12, 50);
            this.cbPoke.Name = "cbPoke";
            this.cbPoke.Size = new System.Drawing.Size(121, 21);
            this.cbPoke.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pokemon Type";
            // 
            // cbMove0
            // 
            this.cbMove0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMove0.FormattingEnabled = true;
            this.cbMove0.Location = new System.Drawing.Point(307, 13);
            this.cbMove0.Name = "cbMove0";
            this.cbMove0.Size = new System.Drawing.Size(124, 21);
            this.cbMove0.TabIndex = 2;
            // 
            // cbMove1
            // 
            this.cbMove1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMove1.FormattingEnabled = true;
            this.cbMove1.Location = new System.Drawing.Point(307, 40);
            this.cbMove1.Name = "cbMove1";
            this.cbMove1.Size = new System.Drawing.Size(124, 21);
            this.cbMove1.TabIndex = 2;
            // 
            // cbMove2
            // 
            this.cbMove2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMove2.FormattingEnabled = true;
            this.cbMove2.Location = new System.Drawing.Point(307, 67);
            this.cbMove2.Name = "cbMove2";
            this.cbMove2.Size = new System.Drawing.Size(124, 21);
            this.cbMove2.TabIndex = 2;
            // 
            // cbMove3
            // 
            this.cbMove3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMove3.FormattingEnabled = true;
            this.cbMove3.Location = new System.Drawing.Point(307, 94);
            this.cbMove3.Name = "cbMove3";
            this.cbMove3.Size = new System.Drawing.Size(124, 21);
            this.cbMove3.TabIndex = 2;
            // 
            // numLv
            // 
            this.numLv.Location = new System.Drawing.Point(139, 50);
            this.numLv.Name = "numLv";
            this.numLv.Size = new System.Drawing.Size(60, 20);
            this.numLv.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Moves:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(307, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "Finished";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChoseSinglePokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 168);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numLv);
            this.Controls.Add(this.cbMove3);
            this.Controls.Add(this.cbMove2);
            this.Controls.Add(this.cbMove1);
            this.Controls.Add(this.cbMove0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPoke);
            this.Name = "ChoseSinglePokemon";
            this.Text = "ChoseSinglePokemon";
            ((System.ComponentModel.ISupportInitialize)(this.numLv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPoke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMove0;
        private System.Windows.Forms.ComboBox cbMove1;
        private System.Windows.Forms.ComboBox cbMove2;
        private System.Windows.Forms.ComboBox cbMove3;
        private System.Windows.Forms.NumericUpDown numLv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}