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
    public class PopUp : GameObject
    {
        private static bool pickedDwarf = true;

        public PopUp(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        public override void OnCollision(GameObject otherObject)
        {
            if (SlaveShip.PurchaseDwarf == true)
            {
                PurchaseDwarf(otherObject);
            }
        }

        public static void PurchaseDwarf(GameObject otherObject)
        {
            Rectangle intersectionFighter = Rectangle.Intersect(otherObject.GetCollisionBox(), SlaveShip.windowFighter.GetCollisionBox());
            Rectangle intersectionMiner = Rectangle.Intersect(otherObject.GetCollisionBox(), SlaveShip.windowMiner.GetCollisionBox());
            MouseControl.PreviousMouse = MouseControl.CurrentMouse;
            MouseControl.CurrentMouse = Mouse.GetState();

            if (otherObject is MouseControl)
            {
                if (intersectionFighter.X > intersectionFighter.Y || intersectionFighter.X < intersectionFighter.Y)
                {
                    if (MouseControl.CurrentMouse.LeftButton == ButtonState.Pressed && pickedDwarf == false && GameWorld.homeBase.GoldAmount >= 15)
                    {
                        // Makes sure only one dwarf gets instantiated per click.
                        while (pickedDwarf == false)
                        {
                            Fighter newOneF = new Fighter(new Vector2(700, 0));
                            GameWorld.NewGameObjects.Add(newOneF);
                            GameWorld.homeBase.GoldAmount -= 15;
                            pickedDwarf = true;
                        }
                    }
                    else
                    {
                        // Resets the bool so dwarfs can be purchased again.
                        pickedDwarf = false;
                    }
                }

                if (intersectionMiner.X > intersectionMiner.Y || intersectionMiner.X < intersectionMiner.Y)
                {
                    if (MouseControl.PreviousMouse.LeftButton == ButtonState.Pressed && pickedDwarf == false && GameWorld.homeBase.GoldAmount >= 15)
                    {
                        // Makes sure only one dwarf gets instantiated per click.
                        while (pickedDwarf == false)
                        {
                            Miner newOneM = new Miner(new Vector2(700, 0));
                            GameWorld.NewGameObjects.Add(newOneM);
                            GameWorld.homeBase.GoldAmount -= 15;
                            pickedDwarf = true;
                        }
                    }
                    else
                    {
                        // Resets the bool so dwarfs can be purchased again.
                        pickedDwarf = false;
                    }
                }
            }
        }
    }
}
