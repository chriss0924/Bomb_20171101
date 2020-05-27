namespace Bomb
{
    partial class Bomb
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
            this.PanelACP = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtACPRecive = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.labBombIndex = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtACPSend = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBomSend = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtBombRecive = new System.Windows.Forms.TextBox();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelACP
            // 
            this.PanelACP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelACP.Location = new System.Drawing.Point(17, 23);
            this.PanelACP.Name = "PanelACP";
            this.PanelACP.Size = new System.Drawing.Size(20, 20);
            this.PanelACP.TabIndex = 10;
            this.PanelACP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClickStatus);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 12);
            this.label17.TabIndex = 11;
            this.label17.Text = "Connect Status";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // txtACPRecive
            // 
            this.txtACPRecive.Enabled = false;
            this.txtACPRecive.Location = new System.Drawing.Point(52, 63);
            this.txtACPRecive.Name = "txtACPRecive";
            this.txtACPRecive.Size = new System.Drawing.Size(289, 22);
            this.txtACPRecive.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 12);
            this.label18.TabIndex = 13;
            this.label18.Text = "Recive";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.labBombIndex);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.txtACPSend);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.PanelACP);
            this.groupBox8.Controls.Add(this.txtACPRecive);
            this.groupBox8.Location = new System.Drawing.Point(3, 145);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(347, 128);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "ACP";
            // 
            // labBombIndex
            // 
            this.labBombIndex.AutoSize = true;
            this.labBombIndex.Location = new System.Drawing.Point(328, 23);
            this.labBombIndex.Name = "labBombIndex";
            this.labBombIndex.Size = new System.Drawing.Size(11, 12);
            this.labBombIndex.TabIndex = 16;
            this.labBombIndex.Text = "1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "Send";
            // 
            // txtACPSend
            // 
            this.txtACPSend.Enabled = false;
            this.txtACPSend.Location = new System.Drawing.Point(52, 91);
            this.txtACPSend.Name = "txtACPSend";
            this.txtACPSend.Size = new System.Drawing.Size(289, 22);
            this.txtACPSend.TabIndex = 14;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.textBomSend);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.txtBombRecive);
            this.groupBox9.Location = new System.Drawing.Point(3, 33);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(347, 89);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Bomb Server";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 12);
            this.label20.TabIndex = 15;
            this.label20.Text = "Send";
            // 
            // textBomSend
            // 
            this.textBomSend.Enabled = false;
            this.textBomSend.Location = new System.Drawing.Point(52, 56);
            this.textBomSend.Name = "textBomSend";
            this.textBomSend.Size = new System.Drawing.Size(289, 22);
            this.textBomSend.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 12);
            this.label22.TabIndex = 13;
            this.label22.Text = "Recive";
            // 
            // txtBombRecive
            // 
            this.txtBombRecive.Enabled = false;
            this.txtBombRecive.Location = new System.Drawing.Point(53, 28);
            this.txtBombRecive.Name = "txtBombRecive";
            this.txtBombRecive.Size = new System.Drawing.Size(289, 22);
            this.txtBombRecive.TabIndex = 12;
            // 
            // Bomb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 286);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Name = "Bomb";
            this.Text = "Bomb System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelACP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtACPRecive;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtACPSend;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBomSend;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtBombRecive;
        private System.Windows.Forms.Label labBombIndex;

    }
}

