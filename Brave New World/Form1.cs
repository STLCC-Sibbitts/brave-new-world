using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
namespace Brave_New_World
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int MAXSECTIONS = 24;
            const int MAXLENGTH = 10;
            //random value
            Random randNumGen = new Random();
            List<List<List<Vector>>> mapdata = new List<List<List<Vector>>>();

            mapdata.Add(new List<List<Vector>>());
            mapdata[0].Add(new List<Vector>());
            double theata = randNumGen.Next(1, MAXSECTIONS);
            int r = randNumGen.Next(1, MAXLENGTH);
            mapdata[0][0].Add(new Vector(Math.Cos(Math.PI * theata / (MAXSECTIONS / 2)) * r, Math.Sin(Math.PI * theata / (MAXSECTIONS / 2))) * r);
            Vector d = mapdata[0][0][0];
            MessageBox.Show(String.Format("[{3},{4}] | [{0},{1}], length of {2}", d.X, d.Y, d.Length, theata * 360 / MAXSECTIONS,r));
        }
    }
}
