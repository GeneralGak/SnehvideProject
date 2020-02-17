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
        public Tree(Texture2D sprite, Vector2 position)
        {
            base.sprite = sprite;
            base.position = position;
        }

        public override void OnCollision(GameObject gameobject)
        {

        }
    }
}
