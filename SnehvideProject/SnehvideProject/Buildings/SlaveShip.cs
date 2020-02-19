using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class SlaveShip : Building, IPlayerUnit
    {
        public SlaveShip(Vector2 position)
        {
            ChangeSprite(Asset.SlaveShip);
            this.position = position;
        }

        public override void OnCollision(GameObject otherObject)
        {
            if (otherObject is MouseControl)
            {
                MouseState state = Mouse.GetState();
                if (state.LeftButton == ButtonState.Pressed)
                {
                    PopUp();
                }
            }
        }

        public static void PopUp()
        {
            GameWorld.GameObjects.Add(new PopUp(Asset.SlaveShipPopUp, new Vector2(500, 1000)));
            GameWorld.GameObjects.Add(new PopUp(Asset.SlaveShipFighter, new Vector2(600, 1100)));
            GameWorld.GameObjects.Add(new PopUp(Asset.SlaveShipMiner, new Vector2(700, 1100)));
        }
    }
}
