﻿using Microsoft.Xna.Framework;
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
        private static PopUp popWindow;
        private static PopUp windowFighter;
        private static PopUp windowMiner;

        private MouseState previousMouse;
        private MouseState currentMouse;

        public SlaveShip(Vector2 position)
        {
            ChangeSprite(Asset.SlaveShip);
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            //When right button is pressed anywhere on the screen, the pop-up disappears.
            if (currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed)
            {
                GameWorld.RemoveGameObject(popWindow);
                GameWorld.RemoveGameObject(windowFighter);
                GameWorld.RemoveGameObject(windowMiner);
            }
        }

        public override void OnCollision(GameObject otherObject)
        {
            if (otherObject is MouseControl)
            {
                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    PopUpWindow();
                }

            }
        }

        public static void PopUpWindow()
        {
            popWindow = new PopUp(Asset.SlaveShipPopUp, new Vector2(500, 500));
            windowFighter = new PopUp(Asset.SlaveShipFighter, new Vector2(600, 600));
            windowMiner = new PopUp(Asset.SlaveShipMiner, new Vector2(700, 600));
            GameWorld.NewGameObjects.Add(popWindow);
            GameWorld.NewGameObjects.Add(windowFighter);
            GameWorld.NewGameObjects.Add(windowMiner);
        }

    }
}
