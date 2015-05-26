using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tanks.GameEngine
{

    public  class World
    {
        /*
         * ВВ: 
         *      1) ця властивість не повинна бути статичною
         *      2) set повинен бути приватним
         */
        public static  char[,] MapArray { get; set; }
        public  World()
        {
            MapArray = new char[20, 20];
            int index = 0;
            char[] mapData = null;
            /*
             * ВВ: не слід використовувати відності шляхи при доступі до файлів,
             * оскільки не відомо точно, якою є поточна папка
             */
            string path = @"../../../Tanks.GameEngine/Maps/map_1.txt";
           
            using (StreamReader reader = new StreamReader(path))
            {
                string mapInfo = reader.ReadToEnd();
                mapData = mapInfo.ToCharArray();
            }
            /*
             * ВВ: не слід використовувати магічні числа
             * краще замінити на MapArray.GetLength(0)
             */
            for (int i = 0; i < 20; i++)
            {
                /*
                 * ВВ: не слід використовувати магічні числа
                 * краще замінити на MapArray.GetLength(1)
                 */
                for (int j = 0; j < 20; j++)
                {
                    MapArray[i, j] = mapData[index];
                    ++index;
                }
            }
        }
    }
}

