using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Brave_New_World
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point[] points = {
               new Point(0, 100),
               new Point(50, 80),
               new Point(100, 20),
               new Point(150, 80),
               new Point(200, 100)};
            Biome biome = new Biome(points, 5);

            txt_keyOutput.SelectedText = biome.GetCustomKey();
        }


    }
}
