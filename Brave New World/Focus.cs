/********************************************************************************************
 * 
 * Class:       Focus
 * Project:     Brave New World
 * Author:      Keith Emery
 * Date:        4/11/14
 * Description: The Focus class comprises an arraylist containing a focus (a point on the map)
 *              and all of the attendant contours (and the physical attributes) that make up 
 *              a feature on the map.
 *              
 * ******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Brave_New_World
{
    class Biome
    {
        // Constants
        const int EQUATOR = 100;

        // Physical attributes received from mesh generator
        private int roundsOfGeneration;
        int m_altitude;
        int latitude;
        int substrate;      
        int[] resources;
        int climate;
        int fauna;
        int vegetationType; // based on USGS descriptions
        Point[] contourPoints; // To determine latitude
        // constructor

        public Biome(int altitude)
        {
            m_altitude = altitude;
        }

        // member functions
        public int RoundsOfGeneration
        {
            get { return roundsOfGeneration; }
            set
            {
                roundsOfGeneration = value;
            }
        }

        public int Altitude
        {
            get { return m_altitude; }
            set { m_altitude = value; }
        }
        
        // test values for now
        public int Substrate
        {
            get { return substrate; }
            set
            {
                if(m_altitude > 5)
                {
                    substrate = 0; // rock
                }
                else if (m_altitude < 5 && m_altitude > 0)
                {
                    substrate = 1; // soil
                }
                else
                {
                    substrate = 2; // water
                }
            }
        }

        public int Climate
        {
            get { return climate; }
            set
            {
                if(latitude > 60)
                {
                    climate = 0; // arctic
                }
            }
        }

        public int getLatitude(int contourPoints)
        {
            return latitude;
        }
    }
}
