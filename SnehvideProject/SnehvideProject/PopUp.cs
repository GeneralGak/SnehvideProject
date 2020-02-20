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
        private bool pressed;

        public PopUp(Texture2D sprite, Vector2 position, float drawLayer)
        {
            this.sprite = sprite;
            this.position = position;
            this.drawLayer = drawLayer;
        }

        public override void OnCollision(GameObject otherObject)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PurchaseDwarf();
        }

        public void PurchaseDwarf()
        {
            MouseState mouseState = Mouse.GetState();
            if (GetCollisionBox().Contains(GameWorld.Point))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                        if (!pressed)
                        {
                            Console.WriteLine("Popup");
                            Fighter newOneF = new Fighter(new Vector2(700, 0));
                            GameWorld.NewGameObjects.Add(newOneF);
                            GameWorld.homeBase.GoldAmount -= 15;
                            pickedDwarf = true;
                            pressed = true;
                        }                    
                }
                

                //if (intersectionMiner.X > intersectionMiner.Y || intersectionMiner.X < intersectionMiner.Y)
                //{
                //    if (MouseControl.PreviousMouse.LeftButton == ButtonState.Pressed && pickedDwarf == false && GameWorld.homeBase.GoldAmount >= 15)
                //    {
                //        // Makes sure only one dwarf gets instantiated per click.
                //        while (pickedDwarf == false)
                //        {
                //            Miner newOneM = new Miner(new Vector2(700, 0));
                //            GameWorld.NewGameObjects.Add(newOneM);
                //            GameWorld.homeBase.GoldAmount -= 15;
                //            pickedDwarf = true;
                //        }
                //    }
                //    else
                //    {
                //        // Resets the bool so dwarfs can be purchased again.
                //        pickedDwarf = false;
                //    }
                //}
            }
            else
            {
                pressed = false;
            }
        }
    }
}
