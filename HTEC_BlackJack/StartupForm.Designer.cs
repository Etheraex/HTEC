namespace HTEC_BlackJack
{
    partial class StartupForm
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
            this.NumberPlayers = new System.Windows.Forms.NumericUpDown();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rankList = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumberPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // NumberPlayers
            // 
            this.NumberPlayers.Location = new System.Drawing.Point(116, 11);
            this.NumberPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.NumberPlayers.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NumberPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumberPlayers.Name = "NumberPlayers";
            this.NumberPlayers.Size = new System.Drawing.Size(99, 20);
            this.NumberPlayers.TabIndex = 0;
            this.NumberPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // StartBtn
            // 
            this.StartBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartBtn.Location = new System.Drawing.Point(0, 334);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(236, 62);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Izaberite broj igraca:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rang lista";
            // 
            // rankList
            // 
            this.rankList.Location = new System.Drawing.Point(9, 62);
            this.rankList.Name = "rankList";
            this.rankList.ReadOnly = true;
            this.rankList.Size = new System.Drawing.Size(214, 255);
            this.rankList.TabIndex = 5;
            this.rankList.Text = "";
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 396);
            this.Controls.Add(this.rankList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.NumberPlayers);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartupForm";
            this.Text = "StartupForm";
            ((System.ComponentModel.ISupportInitialize)(this.NumberPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumberPlayers;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rankList;
    }
}