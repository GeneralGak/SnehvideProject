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
        //private static MouseState currentMouseState;
        //private static MouseState previousMouseState;

        public MouseControl()
        {
            //Loads the correct sprite.
            ChangeSprite(Asset.MouseCursorSprite);
            //Sets the sprite position to be where the mouse is.
            this.Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public override void Update(GameTime gameTime)
        {
            //Makes sure the texture follows the mouse every time the user moves it.
            MouseState mouse = Mouse.GetState();
            this.position.X = mouse.Position.X;
            this.position.Y = mouse.Position.Y;
            base.Update(gameTime);
            drawLayer = 0.8f;
            Console.WriteLine(position.X + " : " + position.Y);
        }

        public override void OnCollision(GameObject otherObject)
        {
            MouseState state = Mouse.GetState();

            // If applemonster or tree is clicked, they disappear from the map. This is just to test the mouse, first and foremost.
            if (otherObject is AppleMonster || otherObject is Tree)
            {
                if (state.LeftButton == ButtonState.Pressed )
                {
                    GameWorld.RemoveGameObject(otherObject);
                }
            }

            // For more buttons. For later. If needed.
            //if (state.RightButton == ButtonState.Pressed)
            //{

            //}

            //if (state.ScrollWheelValue)
            //{

            //}
        }
    }
}
