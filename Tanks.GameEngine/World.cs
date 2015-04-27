using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tanks.GameEngine
{

    public class World
    {
        public static char[,] MapArray { get; set; }
        public World()
        {
            MapArray = new char[20, 20];
            int index = 0;
            char[] mapData = null;
            string path = @"../../../Tanks.GameEngine/Maps/map_1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string mapInfo = reader.ReadToEnd();
                mapData = mapInfo.ToCharArray();
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    MapArray[i, j] = mapData[index];
                    ++index;
                }
            }
        }
    }
}

