using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class MapObject
    {
        // FIELDS
        private static int coordinate;

        // METHODS

        /// <summary>
        /// Empty Constructor for MapObject
        /// </summary>
        public MapObject()
        {

        }

        /// <summary>
        /// Method for generating the map
        /// </summary>
        /// <param name="layerOne"></param>
        /// <param name="layerTwo"></param>
        /// <param name="size"></param>
        public void GenerateMap(int[,] layerOne, int[,] layerTwo, float size)
        {
            // Layer one is for background tiles.
            for (int x = 0; x < layerOne.GetLength(1); x++)
            {
                for (int y = 0; y < layerOne.GetLength(0); y++)
                {
                    coordinate = layerOne[y, x];

                    switch (coordinate)
                    {
                        case (0):
                            {
                                GameObject newGrass = new BackgroundTile(Asset.GrassSprite, new Vector2(x * size, y * size), coordinate);
                                GameWorld.GameObjects.Add(newGrass);
                                break;
                            }
                        case (1):
                            {
                                GameObject newGround = new BackgroundTile(Asset.GroundSprite, new Vector2(x * size, y * size), coordinate);
                                GameWorld.GameObjects.Add(newGround);
                                break;
                            }
                        case (2):
                            {
                                GameObject newWater = new BackgroundTile(Asset.WaterSprite, new Vector2(x * size, y * size), coordinate);
                                GameWorld.GameObjects.Add(newWater);
                                break;
                            }
                    }
                }
            }

            // Layer two is for items: trees, houses etc.
            for (int x = 0; x < layerTwo.GetLength(1); x++)
            {
                for (int y = 0; y < layerTwo.GetLength(0); y++)
                {
                    coordinate = layerTwo[y, x];

                    switch (coordinate)
                    {
                        case (1):
                            {
                                GameWorld.GameObjects.Add(new Tree(Asset.TreeSprite, new Vector2(x * size, y * size)));
                                //GameObject newTree = new Tree(Assets.TreeSprite, new Vector2(x * size, y * size));
                                //GameWorld.GameObjects.Add(newTree);
                                break;
                            }
                        case (2):
                            {
                                GameWorld.GameObjects.Add(new Appletree(Asset.AppletreeSprite, new Vector2(x * size, y * size)));
                                //GameObject newAppletree = new Appletree(Assets.AppletreeSprite, new Vector2(x * size, y * size));
                                //GameWorld.GameObjects.Add(newAppletree);
                                break;
                            }
                    }
                }
            }
        }
    }
}
