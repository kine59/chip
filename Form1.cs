using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie_Clicker
{
    public partial class ChipGame : Form
    {
        public ChipGame()
        {
            InitializeComponent();
        }

        int clicks = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clicks += 1; // this increments the clicks by 1
            Form1_Load(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelClicks.Text = "Clicks: " + clicks.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveclicks = new SaveFileDialog();
            saveclicks.Filter = "CC Save|*.cc";
            DialogResult result = saveclicks.ShowDialog();


            if (DialogResult.OK == result)
            {
                File.WriteAllText(saveclicks.FileName, clicks.ToString());
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openclicks = new OpenFileDialog();
            openclicks.Filter = "CC Save|*.cc";
            DialogResult result = openclicks.ShowDialog();

            if (result == DialogResult.OK) 
            {
                clicks = 0;
                clicks = int.Parse(File.ReadAllText(openclicks.FileName));
                labelClicks.Text = "Clicks: " + clicks.ToString();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chip' by Kine59\nv1.0.0\n\n" +
                "Licensed under the Apache License", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
