using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private static SlaveShip slaveShipSprite;

        // METHODS

        /// <summary>
        /// Empty Constructor for MapObject
        /// </summary>
        public MapObject()
        {

        }

        //Makes sure we can reach it from the PopUp class.
        //This is to ensure the pop-up can spawn at the same position as the ship-sprite.
        public static SlaveShip SlaveShipSprite { get => slaveShipSprite; }

        /// <summary>
        /// Method for generating the map
        /// </summary>
        /// <param name="backGroundLayer"></param>
        /// <param name="objectLayer"></param>
        /// <param name="size"></param>
        public void GenerateMap(Texture2D backGroundLayer, int[,] objectLayer, float size)
        {
            // Background layer is one image.
            GameWorld.GameObjects.Add(new BackgroundTile(backGroundLayer, Vector2.Zero));

            // Object layer is for items: trees, houses etc.
            for (int x = 0; x < objectLayer.GetLength(1); x++)
            {
                for (int y = 0; y < objectLayer.GetLength(0); y++)
                {
                    coordinate = objectLayer[y, x];

                    switch (coordinate)
                    {
                        case (1):
                            {
                                GameWorld.GameObjects.Add(new Tree(Asset.TreeSprite, new Vector2(x * size, y * size)));
                                break;
                            }
                        case (2):
                            {
                                GameWorld.GameObjects.Add(new Appletree(Asset.AppletreeSprite, new Vector2(x * size, y * size)));
                                break;
                            }
                        case (3):
                            {
                                slaveShipSprite = new SlaveShip(new Vector2(x * size, y * size));
                                GameWorld.NewGameObjects.Add(slaveShipSprite);
                                break;
                            }
                    }
                }
            }
        }
    }
}
