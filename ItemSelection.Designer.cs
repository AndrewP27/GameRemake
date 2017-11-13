namespace PokemonRemake
{
    partial class ItemSelection
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
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbItemDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(12, 12);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(233, 21);
            this.cbItems.TabIndex = 0;
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(170, 89);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbItemDesc
            // 
            this.lbItemDesc.Location = new System.Drawing.Point(12, 36);
            this.lbItemDesc.Name = "lbItemDesc";
            this.lbItemDesc.Size = new System.Drawing.Size(233, 50);
            this.lbItemDesc.TabIndex = 3;
            // 
            // ItemSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 120);
            this.Controls.Add(this.lbItemDesc);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbItems);
            this.Name = "ItemSelection";
            this.Text = "ItemSelection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbItemDesc;
    }
}