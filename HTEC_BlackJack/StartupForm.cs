﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTEC_BlackJack
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var numPlayers = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            Form f = new BlackJack(this,numPlayers);
            this.Hide();
            f.ShowDialog();
        }
    }
}