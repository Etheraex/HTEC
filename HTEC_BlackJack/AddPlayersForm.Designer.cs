namespace HTEC_BlackJack
{
    partial class AddPlayersForm
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
            this.p1 = new System.Windows.Forms.Label();
            this.p6 = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.Label();
            this.p4 = new System.Windows.Forms.Label();
            this.p5 = new System.Windows.Forms.Label();
            this.p1Name = new System.Windows.Forms.TextBox();
            this.p2Name = new System.Windows.Forms.TextBox();
            this.p3Name = new System.Windows.Forms.TextBox();
            this.p6Name = new System.Windows.Forms.TextBox();
            this.p5Name = new System.Windows.Forms.TextBox();
            this.p4Name = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.AutoSize = true;
            this.p1.Location = new System.Drawing.Point(43, 39);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(43, 13);
            this.p1.TabIndex = 1;
            this.p1.Text = "Igrac 1:";
            // 
            // p6
            // 
            this.p6.AutoSize = true;
            this.p6.Location = new System.Drawing.Point(43, 238);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(43, 13);
            this.p6.TabIndex = 2;
            this.p6.Text = "Igrac 6:";
            this.p6.Visible = false;
            // 
            // p2
            // 
            this.p2.AutoSize = true;
            this.p2.Location = new System.Drawing.Point(43, 79);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(43, 13);
            this.p2.TabIndex = 3;
            this.p2.Text = "Igrac 2:";
            // 
            // p3
            // 
            this.p3.AutoSize = true;
            this.p3.Location = new System.Drawing.Point(43, 124);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(43, 13);
            this.p3.TabIndex = 4;
            this.p3.Text = "Igrac 3:";
            this.p3.Visible = false;
            // 
            // p4
            // 
            this.p4.AutoSize = true;
            this.p4.Location = new System.Drawing.Point(43, 163);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(43, 13);
            this.p4.TabIndex = 5;
            this.p4.Text = "Igrac 4:";
            this.p4.Visible = false;
            // 
            // p5
            // 
            this.p5.AutoSize = true;
            this.p5.Location = new System.Drawing.Point(43, 203);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(43, 13);
            this.p5.TabIndex = 6;
            this.p5.Text = "Igrac 5:";
            this.p5.Visible = false;
            // 
            // p1Name
            // 
            this.p1Name.Location = new System.Drawing.Point(122, 32);
            this.p1Name.Name = "p1Name";
            this.p1Name.Size = new System.Drawing.Size(100, 20);
            this.p1Name.TabIndex = 7;
            // 
            // p2Name
            // 
            this.p2Name.Location = new System.Drawing.Point(122, 72);
            this.p2Name.Name = "p2Name";
            this.p2Name.Size = new System.Drawing.Size(100, 20);
            this.p2Name.TabIndex = 8;
            // 
            // p3Name
            // 
            this.p3Name.Location = new System.Drawing.Point(119, 117);
            this.p3Name.Name = "p3Name";
            this.p3Name.Size = new System.Drawing.Size(100, 20);
            this.p3Name.TabIndex = 9;
            this.p3Name.Visible = false;
            // 
            // p6Name
            // 
            this.p6Name.Location = new System.Drawing.Point(119, 238);
            this.p6Name.Name = "p6Name";
            this.p6Name.Size = new System.Drawing.Size(100, 20);
            this.p6Name.TabIndex = 10;
            this.p6Name.Visible = false;
            // 
            // p5Name
            // 
            this.p5Name.Location = new System.Drawing.Point(119, 203);
            this.p5Name.Name = "p5Name";
            this.p5Name.Size = new System.Drawing.Size(100, 20);
            this.p5Name.TabIndex = 11;
            this.p5Name.Visible = false;
            // 
            // p4Name
            // 
            this.p4Name.Location = new System.Drawing.Point(119, 163);
            this.p4Name.Name = "p4Name";
            this.p4Name.Size = new System.Drawing.Size(100, 20);
            this.p4Name.TabIndex = 12;
            this.p4Name.Visible = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 54);
            this.button1.TabIndex = 13;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddPlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 334);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.p4Name);
            this.Controls.Add(this.p5Name);
            this.Controls.Add(this.p6Name);
            this.Controls.Add(this.p3Name);
            this.Controls.Add(this.p2Name);
            this.Controls.Add(this.p1Name);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p6);
            this.Controls.Add(this.p1);
            this.Name = "AddPlayersForm";
            this.Text = "AddPlayersForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPlayersForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label p1;
        private System.Windows.Forms.Label p6;
        private System.Windows.Forms.Label p2;
        private System.Windows.Forms.Label p3;
        private System.Windows.Forms.Label p4;
        private System.Windows.Forms.Label p5;
        private System.Windows.Forms.TextBox p1Name;
        private System.Windows.Forms.TextBox p2Name;
        private System.Windows.Forms.TextBox p3Name;
        private System.Windows.Forms.TextBox p6Name;
        private System.Windows.Forms.TextBox p5Name;
        private System.Windows.Forms.TextBox p4Name;
        private System.Windows.Forms.Button button1;
    }
}