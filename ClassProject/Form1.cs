using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassProject
{
    public partial class Form1 : Form
    {

        Graphics drawing;
      
        public Form1()
        {
            InitializeComponent();
            drawing = picboxDrawing.CreateGraphics();
        }

        private void picboxDrawing_Click(object sender, EventArgs e)
        {

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {


            Point[] myPoints = {
  new Point(10, 42),
  new Point(36, 450),
  new Point(35, 84),
  new Point(38, 49),
  new Point(307, 4),
  new Point(3, 94),
  new Point(73,754),
 new Point(83, 54),
 new Point(397, 46),
 new Point(10, 452)
};
            
            
            
            //Pen redPen = new Pen(Color.Red);
            //drawing.DrawLine(redPen, 100, 10, 300, 300);

            //Pen greenPen = new Pen(Color.Green);
            //drawing.DrawLine(greenPen, 300, 300, 350, 62);

            Pen bluePen = new Pen(Color.Blue);
            drawing.DrawBeziers(bluePen, myPoints);// how to graph the shape using the array of points
        }

        
    }
}
