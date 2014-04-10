using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using VectorLandMesh;

namespace vectorTest
{
    /// <summary>
    /// Land Mesh Class 
    /// </summary>
    class LandMesh
    {
        /// <summary>
        /// 
        /// </summary>
        public List<LandContour> LandVectorData{ get; private set;}
        /// <summary>
        /// 
        /// </summary>
        public Point CenterPoint { get; set; }

        /// <summary>
        /// Genarate New Land Mesh Based on a Random Object
        /// </summary>
        public LandMesh(Random seed)
        {
            const int maxX = 16, maxY = 16;
            if (seed!=null)
            {
                this.CenterPoint = new Point(seed.Next(maxX), seed.Next(maxY));
            }
        }
       
        public LandMesh(Double CenterX = 0, Double CenterY = 0, LandContour contour=null)
        {
            this.CenterPoint = new Point(CenterX, CenterY);
            this.LandVectorData = new List<LandContour>();
            if(contour!=null)
                this.LandVectorData.Add(contour);
        }
    }
}
