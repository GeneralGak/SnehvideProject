using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class MapObject
    {
        private int coordinate;
        protected void GenerateLevel(int[,] layerOne, int[,] layerTwo, float size)
        {
            // Layer one is for background tiles.
            for (int x = 0; x < layerOne.GetLength(1); x++)
            {
                for (int y = 0; y < layerOne.GetLength(0); y++)
                {
                    coordinate = layerOne[y, x];

                    switch (coordinate)
                    {
                        case (1):
                            {
                                break;
                            }
                    }
                }
            }

            // Layer for items: trees, houses etc.
            for (int x = 0; x < layerTwo.GetLength(1); x++)
            {
                for (int y = 0; y < layerTwo.GetLength(0); y++)
                {
                    coordinate = layerTwo[y, x];

                    switch (coordinate)
                    {
                        case (1):
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
