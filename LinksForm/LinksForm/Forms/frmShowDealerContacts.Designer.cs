namespace Links.Forms
{
    partial class frmShowDealerContacts
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
            this.dgvDealerContacts = new System.Windows.Forms.DataGridView();
            this.grpDealer = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCTDI = new System.Windows.Forms.TextBox();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.grpMainDealer = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealerContacts)).BeginInit();
            this.grpDealer.SuspendLayout();
            this.grpMainDealer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDealerContacts
            // 
            this.dgvDealerContacts.AllowUserToAddRows = false;
            this.dgvDealerContacts.AllowUserToDeleteRows = false;
            this.dgvDealerContacts.AllowUserToResizeRows = false;
            this.dgvDealerContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDealerContacts.Location = new System.Drawing.Point(6, 29);
            this.dgvDealerContacts.Name = "dgvDealerContacts";
            this.dgvDealerContacts.ReadOnly = true;
            this.dgvDealerContacts.RowHeadersVisible = false;
            this.dgvDealerContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDealerContacts.Size = new System.Drawing.Size(355, 163);
            this.dgvDealerContacts.TabIndex = 4;
            // 
            // grpDealer
            // 
            this.grpDealer.Controls.Add(this.label2);
            this.grpDealer.Controls.Add(this.label1);
            this.grpDealer.Controls.Add(this.txtCTDI);
            this.grpDealer.Controls.Add(this.txtCNPJ);
            this.grpDealer.Location = new System.Drawing.Point(6, 216);
            this.grpDealer.Name = "grpDealer";
            this.grpDealer.Size = new System.Drawing.Size(367, 88);
            this.grpDealer.TabIndex = 5;
            this.grpDealer.TabStop = false;
            this.grpDealer.Text = "grpDealer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CNPJ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CTDI:";
            // 
            // txtCTDI
            // 
            this.txtCTDI.Location = new System.Drawing.Point(73, 28);
            this.txtCTDI.Name = "txtCTDI";
            this.txtCTDI.ReadOnly = true;
            this.txtCTDI.Size = new System.Drawing.Size(81, 20);
            this.txtCTDI.TabIndex = 7;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(73, 53);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.ReadOnly = true;
            this.txtCNPJ.Size = new System.Drawing.Size(152, 20);
            this.txtCNPJ.TabIndex = 6;
            // 
            // grpMainDealer
            // 
            this.grpMainDealer.Controls.Add(this.dgvDealerContacts);
            this.grpMainDealer.Location = new System.Drawing.Point(6, 12);
            this.grpMainDealer.Name = "grpMainDealer";
            this.grpMainDealer.Size = new System.Drawing.Size(367, 198);
            this.grpMainDealer.TabIndex = 6;
            this.grpMainDealer.TabStop = false;
            // 
            // frmShowDealerContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 215);
            this.Controls.Add(this.grpMainDealer);
            this.Controls.Add(this.grpDealer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDealerContacts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dealer Contacts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealerContacts)).EndInit();
            this.grpDealer.ResumeLayout(false);
            this.grpDealer.PerformLayout();
            this.grpMainDealer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDealerContacts;
        private System.Windows.Forms.GroupBox grpDealer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCTDI;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.GroupBox grpMainDealer;
    }
}