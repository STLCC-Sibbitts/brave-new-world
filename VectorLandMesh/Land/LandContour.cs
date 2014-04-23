using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using VectorLandMesh.Data;
namespace VectorLandMesh.Land
{

    public class LandContour
    {
        /// <summary>
        /// 
        /// </summary>
        private Point Center{get;set;}

        /// <summary>
        /// 
        /// </summary>
        private List<double> scaler = new List<double>();
        
        /// <summary>
        /// The Height Level the Contor.
        /// </summary>
        public double Height { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale">used to scale the length of a vectors base on a number between the Min(X), and the Max(Y)</param>
        public LandContour()
        {

        }
        public List<double> Scales { 
            get{
                return scaler;
            }
        }
        public List<Point> RawPoints{
        get{
            double halfradius = Map.Detail / 2;
            double delta = 0D;
            double x = 0;
            double y = 0;
            List<Point> points = new List<Point>();

            for (int i = Map.Detail; i > 0; i--)
            {
                delta = Math.PI * (i / halfradius);

                x = Center.X + (Math.Cos(delta) * scaler[i - 1]);
                y = Center.Y + (Math.Sin(delta) * scaler[i - 1]);
                points.Add(new Point(x, y));

            }
            return points;
        }
        }
        public LandContour(Point center,Point scale, double height, List<double> previousScale=null)
        {
            this.Center = center;
            if (previousScale==null)
            {
                previousScale = new List<double>{0D};
            }
            double min = 0;
            double max = 0;
            double offset=0;
            for (int i = Map.Detail; i > 0; i--)
            {
                offset=ListHandler<double>.getFromTrimedIndex(previousScale, i - 1);
                min = scale.X + offset;
                max = scale.Y + offset;
                int scaleValue = Map.MapSeed.Next((int)min, (int)max);
                this.scaler.Add(scaleValue);
            }
                Height = height;

            // TODO: Complete member initialization
        }
    }
}
