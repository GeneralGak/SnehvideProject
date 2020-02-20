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
        public BackgroundTile(Texture2D sprite, Vector2 position)
        {
            base.sprite = sprite;
            this.position = position;
        }


        public override void OnCollision(GameObject gameobject)
        {

        }

    }
}
