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
        // climate, latitude, altitude, slope, substrate, aspect
        // Constants
        const int SCREEN_HEIGHT = 500;
        const int EQUATOR = 100;
        const int CONTOUR_INTERVAL = 100;
        const int MAX_CONTOUR = 1000;

        // Physical attributes received from mesh generator
        private int roundsOfGeneration;
        Point[] m_locations;
        int m_customKey;


        // constructor
        public Biome(Point[] locations, int rounds)
        {
            int altitude;
            string latitude;
            string slope;
            m_locations = locations;
            roundsOfGeneration = rounds;

            for(int i = 0; i < m_locations.Length; i++)
            {
                altitude = Altitude(m_locations[i]);
                latitude = Latitude(m_locations[i]);
                slope = Slope(m_locations[i]);
            }
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

        public int Altitude(Point p)
        {
            return  (MAX_CONTOUR - roundsOfGeneration);
        }

        public string Aspect(int locationIndex)
        {
            string aspect;
            switch(locationIndex)
            {
                case 0:
                    aspect = "01";
                    break;
                case 1:
                    aspect = "02";
                    break;
                case 2:
                    aspect = "03";
                    break;
                case 3:
                    aspect = "04";
                    break;
                case 4:
                    aspect = "05";
                    break;
                case 5:
                    aspect = "06";
                    break;
                case 6:
                    aspect = "07";
                    break;
                case 7:
                    aspect = "08";
                    break;
                default:
                    aspect = "09";
                    break;
            }
            return aspect;
        }
        
        public string Slope(Point p)
        {
            string slope;
            int x = p.X;
            int y = p.Y;
            if (y / x >= 10)
                slope = "03";
            else if ((y / x < 10) && (y / x >= 5))
                slope = "02";
            else if (y / x < 5)
                slope = "01";
            else
                slope = "00";
            return (slope); // This should work because each point in our point array represents the change
                                // from the prior point (in other words, the difference between point 1 and point 2.
        }

        public string Substrate(int latitude, int altitude, int slope)
        {
            int substrate = 0;
            // the random numbers are a punt as I could not easily pass an array of ints
            // they will require that I prepend a '0' before each returned int.
            Random r = new Random();
            
            // conditionals for tropical substrates
            if((latitude == 1 || (latitude == 2) || (latitude == 3)) && (altitude == 1 || altitude == 2) && (slope == 1 || slope ==2))
            {
                int randomSubstrate = r.Next(2, 4);
                substrate = randomSubstrate;
            }
            // conditionals for arid substrates
            else if((latitude == 0) && (altitude == 0) && (slope == 1 || (slope == 2)))
            {
                int randomSubstrate = r.Next(1, 2);
                substrate = 01;
            }
            // conditionals for dry temperate substrates
            else if((latitude == 3) && (altitude == 1) && (slope == 1))
            {
                int randomSubstrate = r.Next(1,2);
                substrate = randomSubstrate;
            }
            // conditionals for humid temperate substrates
            else if((latitude == 3) && (altitude == 1) && (slope == 2))
            {
                int randomSubstrate = r.Next(1, 4);
                substrate = randomSubstrate;
            }
            // conditionals for cool temperate substrates
            else if((latitude == 3) && (altitude == 2 || altitude == 3) && (slope == 2))
            {
                int randomSubstrate = r.Next(1, 4);
                substrate = randomSubstrate;
            }
            // conditionals for alpine substrates
            else if((latitude == 0) && (altitude == 3) && (slope == 3))
            {
                int randomSubstrate = r.Next(1, 3);
                if (randomSubstrate == 2)
                    randomSubstrate = 4;
                substrate = randomSubstrate;
            }
            // conditional for polar substrates
            else if((latitude == 4) && (altitude == 1) && (slope == 0))
            {
                substrate = 00;
            }
            // default substrate is rock if all other conditions fail.
            else
            {
                substrate = 1;
            }
            return substrate.ToString("D2");
        }

        public string Latitude(Point p)
        {
            int y = p.Y;
            int latitude;
            if(y < EQUATOR) // if our location is north of the equator
            {
                latitude = (90 - (y * 180) / SCREEN_HEIGHT);
            }
            else            // if our location is south of the equator
            {
                latitude = (((y * 180) / SCREEN_HEIGHT) - 90);
            }
            return latitude.ToString("D2");
        }
    }
}
