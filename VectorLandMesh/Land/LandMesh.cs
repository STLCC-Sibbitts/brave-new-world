using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using VectorLandMesh.Data;

namespace VectorLandMesh.Land
{
    /// <summary>
    /// Land Mesh Class 
    /// </summary>
    public class LandMesh
    {

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public List<Point> MinMaxVectorLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<double> HeightScaling { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfLevel { get; set; }
        /// <summary>
        /// The Height Level of the Mesh
        /// </summary>
        public double HeightLevel
        {
            get
            {
                double height = 0;
                for(int i=NumberOfLevel;i>0;i--)
                {
                    height += (HeightScaling.Count > i) ? HeightScaling[i] : HeightScaling[HeightScaling.Count - 1];
                }
                //return the height level of the first contour.
                return height;
            }
        }

        /// <summary>
        /// A List of Contours for each level of the map.
        /// </summary>
        public List<LandContour> LandVectorData { get; private set; }

        /// <summary>
        /// Central point of mesh 
        /// </summary>
        public Point CenterPoint { get; set; }
        #endregion
            
        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="contour"></param>
        public LandMesh(Double CenterX = 0, Double CenterY = 0, LandContour contour = null,int levels=0)
        {
            this.CenterPoint = new Point(CenterX, CenterY);
            this.LandVectorData = new List<LandContour>();
            if (contour != null)
                this.LandVectorData.Add(contour);
        }

        /// <summary>
        /// Genarate New Land Mesh Based on a Random seed with only one Contour
        /// </summary>
        /// <param name="minMaxWidths"></param>
        /// <param name="heightScaling"></param>
        /// Notes:: It is a reffrance to the seed because new random numbers can be created with out calling a new seed or starting over the previous seed.
        public LandMesh(List<Point> minMaxWidths, List<double> heightScaling,int levels)
        {
            this.Initialize(minMaxWidths, heightScaling, levels);
        }

        /// <summary>
        /// Initilization of New Land Mesh.
        /// </summary>
        /// <param name="minMaxWidths"></param>
        /// <param name="heightScaling"></param>
        /// Notes:: It is a reffrance to the seed because new random numbers can be created with out calling a new seed or starting over the previous seed.
        public void Initialize(List<Point> minMaxWidths, List<double> heightScaling, int levels)
        {
            //Set Properties
            MinMaxVectorLength = minMaxWidths;
            HeightScaling = heightScaling;
            LandVectorData = new List<LandContour>();
            //max height and width of the map to be set latter by setings
            //only if seed is not null continue.
            if (Map.MapSeed==null)
            {
                Map.InitializeSeed();
            }
            this.CenterPoint = new Point(Map.MapSeed.Next((int)Map.Box[0], (int)Map.Box[2]), Map.MapSeed.Next((int)Map.Box[1], (int)Map.Box[3]));
            NumberOfLevel = levels;
            this.addNewContour();
                
        }

        /// <summary>
        /// Genarate New Land Mesh Based on a Random seed with only one Contour
        /// </summary>
        /// <param name="minMaxVectorLength"></param>
        /// <param name="heightScaling"></param>
        /// Notes:: It is a reffrance to the seed because new random numbers can be created with out calling a new seed or starting over the previous seed.
        public LandMesh(Point minMaxVectorLength, double heightScaling, int levels)
        {
            this.Initialize(new List<Point> { minMaxVectorLength }, new List<double> { heightScaling }, levels);
        }
      
        /// <summary>
        /// Adds a new Contour to the Mesh
        /// </summary>
        /// <param name="seed">Refrence to the Random seed</param>
        public void addNewContour()
        {
            double height = 0;
            List<double> previousScale = null;
            Point scaleMaxMin = new Point();
            LandContour previousContour = ListHandler<LandContour>.getNullIfOutOfRange(LandVectorData, LandVectorData.Count - 1);
            if (LandVectorData.Count > 0)
            {
               height = LandVectorData[LandVectorData.Count - 1].Height;
               height -= ListHandler<double>.getFromTrimedIndex(HeightScaling, LandVectorData.Count);

            }
            else
            {
                height = HeightLevel;
            }
                 

            // the scale of the new contor, used when 
            scaleMaxMin = ListHandler<Point>.getFromTrimedIndex(MinMaxVectorLength,LandVectorData.Count);
            if (previousContour==null)
            {
                previousScale = null;
            }
            else
            {
                previousScale = previousContour.Scales;
            }
            // add a new Contour to the end of the list
            LandVectorData.Add(new LandContour(CenterPoint,scaleMaxMin, height, previousScale));
        }

        public List<List<Point>> Points { 
            get{
                List<List<Point>> points = new List<List<Point>>();
                foreach (LandContour contor in LandVectorData)
                {
                    points.Add(contor.RawPoints);
                }
                return points;
            }
        }
        #endregion

        #region Private Methods

        #endregion
            
    }
}