using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class Tree : GameObject
    {
        // METHODS 

        /// <summary>
        /// Constructor for the Tree class
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public Tree(Texture2D sprite, Vector2 position)
        {
            base.sprite = sprite;
            this.position = position;
            drawLayer = 0.03f;
        }

        public override void OnCollision(GameObject gameobject)
        {

        }
    }
}
