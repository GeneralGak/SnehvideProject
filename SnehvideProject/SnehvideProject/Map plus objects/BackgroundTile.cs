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
        // FIELDS
        private int coordinate;

        /// <summary>
        /// Constructor for backgroundtiles ie. grass, ground, water. 
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="coordinate"></param>
        public BackgroundTile(Texture2D sprite, Vector2 position, int coordinate)
        {
            base.sprite = sprite;
            this.position = position;
            this.coordinate = coordinate;
        }


        public override void OnCollision(GameObject gameobject)
        {

        }

    }
}
