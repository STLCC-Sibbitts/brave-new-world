using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using VectorLandMesh;

namespace VectorLandMesh
{
    namespace Land
    {
        /// <summary>
        /// Land Mesh Class 
        /// </summary>
        public class LandMesh
        {
            #region Properties
            /// <summary>
            /// The Height Level of the Mesh
            /// </summary>
            public int HeightLevel
            {
                get
                {
                    return LandVectorData.Count;
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
            public LandMesh(Double CenterX = 0, Double CenterY = 0, LandContour contour = null)
            {
                this.CenterPoint = new Point(CenterX, CenterY);
                this.LandVectorData = new List<LandContour>();
                if (contour != null)
                    this.LandVectorData.Add(contour);
            }

            /// <summary>
            /// Genarate New Land Mesh Based on a Random seed with only one Contour
            /// </summary>
            /// <param name="seed">refrence to the Random seed.</param>
            /// Notes:: It is a reffrance to the seed because new random numbers can be created with out calling a new seed or starting over the previous seed.
            public LandMesh(ref Random seed)
            {
                LandVectorData = new List<LandContour>();
                const int maxX = 16, maxY = 16;
                //only if seed is not null continue.
                if (seed != null)
                {
                    this.CenterPoint = new Point(seed.Next(maxX), seed.Next(maxY));
                    this.addNewContour(ref seed);
                }
            }
      
            /// <summary>
            /// Adds a new Contour to the Mesh
            /// </summary>
            /// <param name="seed">Refrence to the Random seed</param>
            /// <param name="atLevel">At what Level will the Contor be placed at. Default at the end</param>
            public void addNewContour(ref Random seed,int atLevel = -1)
            {
                //set current level equal to the number of Contors
                int level = LandVectorData.Count()+1;

                //if atLevel was not set add a new Contour to the end of the list
                if (atLevel == -1)
                    LandVectorData.Add(new LandContour(seed,level));
                //if it was changed to a valiad number (x > -1) then add to the list at that point
                else if (atLevel > -1)
                    LandVectorData.Insert(atLevel, new LandContour(seed, level));
                //Else An Error Has Occured
                else
                {
                    //TODO: Create Error Handaling
                }

            }
            
            #endregion
            #region Private Methods
            #endregion
        }
    }
}