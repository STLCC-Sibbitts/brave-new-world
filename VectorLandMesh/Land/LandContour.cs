using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace VectorLandMesh
{
    namespace Land
    {
        public class LandContour
        {
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
            public LandContour(Point scale,double height)
            {
                const int NUMBER_OF_POINTS = 16;
                double randomValue = 0;
                for (int i = NUMBER_OF_POINTS; i > 0; i--)
                {
                    randomValue = Map.MapSeed.NextDouble();
                    double scaleValue = scale.X + (scale.Y - scale.X) * randomValue;
                    this.scaler.Add(scaleValue);
                }
                    Height = height;

                // TODO: Complete member initialization
            }

            
        }
    }
}
