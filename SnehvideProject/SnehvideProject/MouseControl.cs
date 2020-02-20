using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class MouseControl : GameObject
    {
        private static MouseState previousMouse;
        private static MouseState currentMouse;

        public static MouseState PreviousMouse { get => previousMouse; set => previousMouse = value; }
        public static MouseState CurrentMouse { get => currentMouse; set => currentMouse = value; }

        public MouseControl()
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Makes sure the texture follows the mouse every time the user moves it.
            MouseState mouse = Mouse.GetState();
            this.position.X = mouse.Position.X;
            this.position.Y = mouse.Position.Y;

            base.Update(gameTime);
            drawLayer = 0.8f;
        }

        public override void OnCollision(GameObject otherObject)
        {

        }
    }
}
