using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLandMesh.Land
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
        public static float[] Box { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static int Detail { get; set; }
        public static void InitializeMap(int detail, float[] box)
        {
            Detail = detail;
            Box = box;
            seed = new Random();
        }
        public static void InitializeMap(int detail, float[] box, int seedValue)
        {
            InitializeMap(detail, box);
            seed = new Random(seedValue);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void InitializeSeed()
        {

            seed = new Random();
        }
        /// <summary>
        /// 
        /// </summary>
        public static Random MapSeed
        {
            get
            {
                return seed;
            }
        }



        
    }

}
