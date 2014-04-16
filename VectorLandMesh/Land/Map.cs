using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLandMesh
{
        namespace Land
    {
        public class Map
        {
            /// <summary>
            /// 
            /// </summary>
            private static Random seed = null;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="seedValue"></param>
            public static void InitializeSeed(int seedValue)
            {

                seed = new Random(seedValue);
            }
            public static void InitializeSeed()
            {

                seed = new Random();
            }
            public static Random MapSeed
            {
                get
                {
                    return seed;
                }
            }
        }
    }
}
