
namespace RealtyApp
{
    partial class RealtorIDSearch
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRealtorID = new System.Windows.Forms.Label();
            this.txtRealtorID = new System.Windows.Forms.TextBox();
            this.lblIDError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(37, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Load";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRealtorID
            // 
            this.lblRealtorID.AutoSize = true;
            this.lblRealtorID.Location = new System.Drawing.Point(8, 19);
            this.lblRealtorID.Name = "lblRealtorID";
            this.lblRealtorID.Size = new System.Drawing.Size(58, 15);
            this.lblRealtorID.TabIndex = 1;
            this.lblRealtorID.Text = "Realtor ID";
            // 
            // txtRealtorID
            // 
            this.txtRealtorID.Location = new System.Drawing.Point(72, 16);
            this.txtRealtorID.Name = "txtRealtorID";
            this.txtRealtorID.Size = new System.Drawing.Size(109, 23);
            this.txtRealtorID.TabIndex = 2;
            this.txtRealtorID.TextChanged += new System.EventHandler(this.txtRealtorID_OnGotFocus);
            // 
            // lblIDError
            // 
            this.lblIDError.AutoSize = true;
            this.lblIDError.BackColor = System.Drawing.SystemColors.Control;
            this.lblIDError.ForeColor = System.Drawing.Color.Red;
            this.lblIDError.Location = new System.Drawing.Point(32, 42);
            this.lblIDError.Name = "lblIDError";
            this.lblIDError.Size = new System.Drawing.Size(121, 15);
            this.lblIDError.TabIndex = 3;
            this.lblIDError.Text = "This ID does not exist.";
            this.lblIDError.Visible = false;
            // 
            // RealtorIDSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 110);
            this.Controls.Add(this.lblIDError);
            this.Controls.Add(this.txtRealtorID);
            this.Controls.Add(this.lblRealtorID);
            this.Controls.Add(this.btnSearch);
            this.Name = "RealtorIDSearch";
            this.Text = "RealtorIDSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblRealtorID;
        private System.Windows.Forms.TextBox txtRealtorID;
        private System.Windows.Forms.Label lblIDError;
    }
}