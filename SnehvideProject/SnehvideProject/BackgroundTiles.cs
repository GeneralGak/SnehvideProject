using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class BackgroundTiles : GameObject
    {
        public BackgroundTiles(Texture2D sprite)
        {
            base.sprite = sprite;
        }

        public override void Update(GameTime gametime)
        {

        }

        public override void OnCollision(GameObject gameobject)
        {

        }
    }
}
