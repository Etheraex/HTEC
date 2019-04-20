using HTEC_BlackJack_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTEC_BlackJack
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            LoadRankList();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            var numPlayers = Convert.ToInt32(Math.Round(NumberPlayers.Value, 0));
            Form f = new AddPlayersForm(this,numPlayers);
            this.Hide();
            f.ShowDialog();
        }

        private void LoadRankList()
        {
            var tmp = new List<Player>();
            String[] rows;
            using (var sr = new StreamReader("Data/SavedScores.txt"))
            {
                rows = Regex.Split(sr.ReadToEnd(), "\n");
            }
            foreach(var s in rows)
            {
                String[] values = Regex.Split(s, " ");
                if(values.Count() == 2)
                    tmp.Add(new Player(values[0], Int32.Parse(values[1])));
            }
            tmp.Sort();
            var j = 1;
            for (var i = tmp.Count - 1; i >= 0 && j < 11; i--)
            {
                rankList.AppendText(j.ToString() + ": " + tmp[i].ToString() + "\n");
                j++;
            }
        }
    }
}
