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
        public static PopUp windowFighter;
        public static PopUp windowMiner;

        //private MouseState previousMouse;
        //private MouseState currentMouse;

        private static bool purchaseDwarf = false;

        public static PopUp PopWindow { get => popWindow; set => popWindow = value; }
        public static PopUp WindowFighter { get => windowFighter; set => windowFighter = value; }
        public static PopUp WindowMiner { get => windowMiner; set => windowMiner = value; }
        public static bool PurchaseDwarf { get => purchaseDwarf; set => purchaseDwarf = value; }

        public SlaveShip(Vector2 position)
        {
            ChangeSprite(Asset.SlaveShip);
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            MouseControl.PreviousMouse = MouseControl.CurrentMouse;
            MouseControl.CurrentMouse = Mouse.GetState();

            PopUpWindow();

            //When right button is pressed anywhere on the screen, the pop-up disappears.
            if (MouseControl.CurrentMouse.RightButton == ButtonState.Released && MouseControl.PreviousMouse.RightButton == ButtonState.Pressed)
            {
                GameWorld.RemoveGameObject(PopWindow);
                GameWorld.RemoveGameObject(WindowFighter);
                GameWorld.RemoveGameObject(WindowMiner);
                // Bool to make sure the dwarfs can be purchased in PopUp class.
                PurchaseDwarf = false;
            }
        }

        public override void OnCollision(GameObject otherObject)
        {

        }

        public void PopUpWindow()
        {
            if(GetCollisionBox().Contains(GameWorld.Point))
            {
                if (MouseControl.CurrentMouse.LeftButton == ButtonState.Released && MouseControl.PreviousMouse.LeftButton == ButtonState.Pressed)
                {
                    PopWindow = new PopUp(Asset.SlaveShipPopUp, new Vector2(MapObject.SlaveShipSprite.position.X - Asset.SlaveShipPopUp.Width * 1.5f, MapObject.SlaveShipSprite.position.Y - Asset.SlaveShipPopUp.Height));
                    //For testing
                    //WindowFighter = new PopUp(Asset.SlaveShipFighter, new Vector2(500, 0));
                    //WindowMiner = new PopUp(Asset.SlaveShipMiner, new Vector2(600, 0));
                    WindowFighter = new PopUp(Asset.SlaveShipFighter, new Vector2(MapObject.SlaveShipSprite.position.X + Asset.SlaveShipFighter.Width * 3 - Asset.SlaveShipPopUp.Width *1.5f, MapObject.SlaveShipSprite.position.Y + Asset.SlaveShipFighter.Height * 3 - Asset.SlaveShipPopUp.Height));
                    WindowMiner = new PopUp(Asset.SlaveShipMiner, new Vector2(MapObject.SlaveShipSprite.position.X + Asset.SlaveShipMiner.Width * 5 - Asset.SlaveShipPopUp.Width * 1.5f, MapObject.SlaveShipSprite.position.Y + Asset.SlaveShipMiner.Height * 2.45f - Asset.SlaveShipPopUp.Height));
                    GameWorld.NewGameObjects.Add(PopWindow);
                    GameWorld.NewGameObjects.Add(WindowFighter);
                    GameWorld.NewGameObjects.Add(WindowMiner);
                    // Bool to make sure the dwarfs can be purchased in PopUp class.
                    PurchaseDwarf = true;
                    Console.WriteLine(PurchaseDwarf);
                }
            }
        }
    }
}
