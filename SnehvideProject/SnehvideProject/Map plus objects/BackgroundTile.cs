using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class BackgroundTile : GameObject
    {
        private int coordinate;
        public BackgroundTile(Vector2 position, int coordinate)
        {
            this.position = position;
            this.coordinate = coordinate;
        }


        public override void OnCollision(GameObject gameobject)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            Texture2D GrassSprite = content.Load<Texture2D>("tile_02");
            Texture2D GroundSprite = content.Load<Texture2D>("tile_06");
            Texture2D WaterSprite = content.Load<Texture2D>("tile_19");

            switch (coordinate)
            {
                case (0):
                    sprite = /*Assets.*/GrassSprite;
                    break;
                case (1):
                    sprite = /*Assets.*/GroundSprite;
                    break;
                case (2):
                    sprite = /*Assets.*/WaterSprite;
                    break;
            }
        }
    }
}
