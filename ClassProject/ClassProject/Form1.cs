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
            //int MAX_SECTIONS = 8;
            //int theata = 1;
            int x1 = 0;
            int y1 = 0;
            int r = 120;
            int detail = 16;
            double halfradius = detail / 2;
            int c = 200;
            Point newpoint = new Point();
        

            List<Point > points = new List <Point >();

            Random seed = new Random();


            for (int i = detail; i > 0; i--)
            {
                r = seed.Next(100, 140);
                x1 = c + (int)(Math.Cos(Math.PI * (i / halfradius)) * r);
                y1 = c + (int)(Math.Sin(Math.PI * (i / halfradius)) * r);

                 newpoint = new Point(x1, y1);
                 points.Add(newpoint);
            }

            
            Point[] myPoints = points.ToArray<Point>();



            //Pen redPen = new Pen(Color.Red);
            //drawing.DrawLine(redPen, 100, 10, 300, 300);

            //Pen greenPen = new Pen(Color.Green);
            //drawing.DrawLine(greenPen, 300, 300, 350, 62);

            Pen bluePen = new Pen(Color.Blue);
            drawing.DrawClosedCurve(bluePen, myPoints);// how to graph the shape using the array of points
        }

        
    }
}










//int x1 = (int)(c + Math.Cos(Math.PI * .25) * r);
//int y1 = (int)(c + Math.Sin(Math.PI * .25) * r);

//int x2 = (int)(c + Math.Cos(Math.PI * .5) * r);
//int y2 = (int)(c + Math.Sin(Math.PI * .5) * r);

//int x3 = (int)(c + Math.Cos(Math.PI * .75) * r);
//int y3 = (int)(c + Math.Sin(Math.PI * .75) * r);

//int x4 = (int)(c + Math.Cos(Math.PI * 1) * r);
//int y4 = (int)(c + Math.Sin(Math.PI * 1) * r);

//int x5 = (int)(c + Math.Cos(Math.PI * 1.25) * r);
//int y5 = (int)(c + Math.Sin(Math.PI * 1.25) * r);

//int x6 = (int)(c + Math.Cos(Math.PI * 1.5) * r);
//int y6 = (int)(c + Math.Sin(Math.PI * 1.5) * r);









//Point point1 = new Point(Math.Cos(Math.PI * theata / (MAX_SECTIONS / 2)) * r, Math.Sin(Math.PI * theata / (MAX_SECTIONS / 2))) * r;




//            Point[] myPoints = {
//  new Point(x1, y1),
//  new Point(x2, y2),
//  new Point(x3, y3),
//  new Point(x4, y4),
//  new Point(x5, y5),
//  new Point(x6, y6),
//  new Point(x1, y1)
//};
