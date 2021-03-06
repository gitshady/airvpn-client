﻿namespace AirVPN.Gui.Forms
{
	partial class OpenVpnManagementCommand
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenVpnManagementCommand));
			this.lnkHelp = new AirVPN.Gui.Skin.LinkLabel();
			this.cmdOk = new AirVPN.Gui.Skin.Button();
			this.cmdCancel = new AirVPN.Gui.Skin.Button();
			this.txtCommand = new AirVPN.Gui.Skin.TextBox();
			this.lblCommand = new AirVPN.Gui.Skin.Label();
			this.SuspendLayout();
			// 
			// lnkHelp
			// 
			this.lnkHelp.AutoSize = true;
			this.lnkHelp.BackColor = System.Drawing.Color.Transparent;
			this.lnkHelp.ForeColor = System.Drawing.Color.Black;
			this.lnkHelp.Location = new System.Drawing.Point(34, 61);
			this.lnkHelp.Name = "lnkHelp";
			this.lnkHelp.Size = new System.Drawing.Size(345, 13);
			this.lnkHelp.TabIndex = 41;
			this.lnkHelp.TabStop = true;
			this.lnkHelp.Text = "Click here for more informations about OpenVPN Management Interface";
			this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHelp_LinkClicked);
			// 
			// cmdOk
			// 
			this.cmdOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdOk.BackgroundImage")));
			this.cmdOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cmdOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOk.FlatAppearance.BorderSize = 0;
			this.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdOk.Location = new System.Drawing.Point(100, 103);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(100, 28);
			this.cmdOk.TabIndex = 5;
			this.cmdOk.Text = "Send";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
			this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatAppearance.BorderSize = 0;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.Location = new System.Drawing.Point(206, 103);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(100, 28);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// txtCommand
			// 
			this.txtCommand.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCommand.Location = new System.Drawing.Point(89, 18);
			this.txtCommand.Name = "txtCommand";
			this.txtCommand.Size = new System.Drawing.Size(269, 20);
			this.txtCommand.TabIndex = 1;
			this.txtCommand.Text = "help";
			// 
			// lblCommand
			// 
			this.lblCommand.BackColor = System.Drawing.Color.Transparent;
			this.lblCommand.ForeColor = System.Drawing.Color.Black;
			this.lblCommand.Location = new System.Drawing.Point(12, 21);
			this.lblCommand.Name = "lblCommand";
			this.lblCommand.Size = new System.Drawing.Size(72, 20);
			this.lblCommand.TabIndex = 40;
			this.lblCommand.Text = "Command :";
			this.lblCommand.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// OpenVpnManagementCommand
			// 
			this.AcceptButton = this.cmdOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(407, 145);
			this.Controls.Add(this.lnkHelp);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.txtCommand);
			this.Controls.Add(this.lblCommand);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenVpnManagementCommand";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.SettingsRoute_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private Skin.Button cmdOk;
        private Skin.Button cmdCancel;
        private Skin.TextBox txtCommand;
		private Skin.Label lblCommand;
		private Skin.LinkLabel lnkHelp;
    }
}