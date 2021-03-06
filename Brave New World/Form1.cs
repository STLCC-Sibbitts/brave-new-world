﻿using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows;
using System.Windows.Forms;

using VectorLandMesh.Land;
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
        private static List<System.Drawing.Point> ToDrawingPoints(List<System.Windows.Point> windowsPoint)
        {
            List<System.Drawing.Point> drawingPoints = new List<System.Drawing.Point>();
            foreach (System.Windows.Point point in windowsPoint)
            {
                drawingPoints.Add(new System.Drawing.Point((int)point.X, (int)point.Y));
            }
            return drawingPoints;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        /*
        private void grop(int center)
        {
            //int MAX_SECTIONS = 8;
            //int theata = 1;
            int x1 = 0;
            int y1 = 0;
            int r = 0;
            int levels = 6;
            int detail = 32;
            double halfradius = detail / 2;
            int c = center;
            int scaleBar = 0;
            Point newpoint = new Point();

            List<Color> color = new List<Color>(new Color[] { Color.Blue, Color.Purple,Color.Red, Color.Orange, Color.Yellow, Color.Green });
            List<List<Point>> points = new List<List<Point>>();

            List<int> scale = new List<int>();

            List<int> verticalScale = new List<int>();

            Random seed = new Random();
            for (int y = detail; y > 0; y--)
            {
                scale.Add(30);
            }
            for (int y = levels; y > 0; y--)
            {
                verticalScale.Add(((levels - y) * 20) + 40);
                points.Add(new List<Point>());
                for (int x = detail; x > 0; x--)
                {
                    r = seed.Next(scale[x - 1], verticalScale[points.Count - 1]);
                    scale[x - 1] = r + 10;

                    x1 = c + (int)(Math.Cos(Math.PI * (x / halfradius)) * r);
                    y1 = c + (int)(Math.Sin(Math.PI * (x / halfradius)) * r);

                    newpoint = new Point(x1, y1);

                    points[points.Count - 1].Add(newpoint);
                }
            }
            

            for (int y = levels - 1; y >= 0; y--)
            {
                Point[] myPoints = points[y].ToArray<Point>();
                Pen bluePen = new Pen(color[y]);
                drawing.FillClosedCurve(new SolidBrush(color[y]), myPoints);// how to graph the shape using the array of points
            }

            //Pen redPen = new Pen(Color.Red);
            //drawing.DrawLine(redPen, 100, 10, 300, 300);

            //Pen greenPen = new Pen(Color.Green);
            //drawing.DrawLine(greenPen, 300, 300, 350, 62);
        }
        */
        private void btnDraw_Click(object sender, EventArgs e)
        {
            drawing.Clear(Color.Blue);
                          List<Color> color = new List<Color>();

            //
            int meshOnLevel = 0;

            //odds map will be generated by Map settings.
            int[] oddsMap = { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4 };
            //int[] oddsMap = { 1, 1, 1, 1};
            /*  CONSTS: Need To replace with class for map Properties
             * MAX_SECTIONS     : Max number of section each contour is divide in to.
             * MAX_LENGTH       : Max length of each Contours Vector
             * LEVELS           : Number of Levels for each mesh.
             * min number of Land Meshes per level
             */
            const int MAX_SECTIONS = 16, MAX_LENGTH = 10, LEVELS = 16;
            for (int i = LEVELS; i > 0; i--)
            {
                color.Add(Color.FromArgb(i * 255 / LEVELS, i * 255 / LEVELS, i * 255 / LEVELS));
                
            }
            //test for map data. will be set in to class List
            List<LandMesh> mapMeshData = new List<LandMesh>();

            //used later in loop on [Line 46]
            LandMesh land;
            Map.InitializeMap(MAX_SECTIONS, new float[] { drawing.VisibleClipBounds.X, drawing.VisibleClipBounds.Y, drawing.VisibleClipBounds.Width, drawing.VisibleClipBounds .Height});
            //grabs a randum number form an odds map.
            meshOnLevel = oddsMap[Map.MapSeed.Next(0, oddsMap.Length - 1)];
            oddsMap[0] = 0;
            oddsMap[1] = 0;

            for (int x = LEVELS; x > 0; x--)
            {
                //adds new Contour for each existing mesh.                
                foreach (LandMesh mesh in mapMeshData)
                {
                    mesh.addNewContour();
                }

                //add new land mesh(s)
                for (int y = meshOnLevel; y > 0; y--)
                {
                    land = new LandMesh(new System.Windows.Point(10, 20), 10D, x);
                    mapMeshData.Add(land);
                }

                //grabs a randum number form an odds map.
                meshOnLevel = oddsMap[Map.MapSeed.Next(0, oddsMap.Length - 1)];
            }
            //adds new a Contour for existing meshes.
            foreach (LandMesh mesh in mapMeshData)
            {
                //add new contour to the end of every mesh
                mesh.addNewContour();
            }
            double drpo = mapMeshData[0].HeightLevel;
            //soon to be removed for Class Structure
            List<List<List<System.Windows.Point>>> mapdata = new List<List<List<System.Windows.Point>>>();
            System.Windows.Point d;
            foreach (LandMesh mesh in mapMeshData)
            {
                mapdata.Add(mesh.Points);
            }
            List<int> offsets = new List<int>();
            int y2=0;
            for (int y = LEVELS; y >0; y--)
            {

                for (int x = 0 ; x < mapMeshData.Count; x++)
                {
                    if (y == LEVELS)
                    {
                        offsets.Add(y-mapMeshData[x].NumberOfLevel);
                    }
                    y2=y-offsets[x];
                    if(y2>=0){
                        System.Drawing.Point[] myPoints = Form1.ToDrawingPoints(mapdata[x][y2]).ToArray<System.Drawing.Point>();
                        drawing.FillClosedCurve(new SolidBrush(color[y-1]), myPoints);// how to graph the shape using the array of points
                    }
                }
            }
            
        }

        
    }
}
