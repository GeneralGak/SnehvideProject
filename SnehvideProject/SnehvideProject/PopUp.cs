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
            drawLayer = 0.2f;
        }

        public override void OnCollision(GameObject otherObject)
        {
            if (SlaveShip.PurchaseDwarf == true)
            {
                PurchaseDwarf();
                //pickedDwarf = false;
            }
        }

        public void PurchaseDwarf()
        {
            if (GetCollisionBox().Contains(GameWorld.Point))
            {
                if (sprite == Asset.SlaveShipFighter)
                {
                    if (MouseControl.CurrentMouse.LeftButton == ButtonState.Pressed && pickedDwarf == false /*&& GameWorld.homeBase.GoldAmount >= 15*/)
                    {
                        // Makes sure only one dwarf gets instantiated per click.
                        while (pickedDwarf == false)
                        {
                            Fighter newOneF = new Fighter(new Vector2(MapObject.SlaveShipSprite.Position.X - Asset.DwarfFighterSprite.Width * 30, MapObject.SlaveShipSprite.Position.Y));
                            GameWorld.NewGameObjects.Add(newOneF);
                            //GameWorld.homeBase.GoldAmount -= 15;
                            pickedDwarf = true;
                        }
                    }
                    else
                    {
                        // Resets the bool so dwarfs can be purchased again.
                        pickedDwarf = false;
                    }
                }

                if (sprite == Asset.SlaveShipMiner)
                {
                    if (MouseControl.PreviousMouse.LeftButton == ButtonState.Pressed && pickedDwarf == false/* && GameWorld.homeBase.GoldAmount >= 15*/)
                    {
                        // Makes sure only one dwarf gets instantiated per click.
                        while (pickedDwarf == false)
                        {
                            Miner newOneM = new Miner(new Vector2(MapObject.SlaveShipSprite.Position.X - Asset.DwarfMinerSprite.Width * 30, MapObject.SlaveShipSprite.Position.Y));
                            GameWorld.NewGameObjects.Add(newOneM);
                            /*GameWorld.homeBase.GoldAmount -= 15;*/
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
