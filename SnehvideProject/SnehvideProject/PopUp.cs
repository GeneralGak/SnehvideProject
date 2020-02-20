using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
	public class PopUp : GameObject
	{
		private static bool pickedDwarf = true;
		private MouseState prevMouse, curMouse;

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
			prevMouse = curMouse;
			curMouse = Mouse.GetState();
			//When right button is pressed anywhere on the screen, the pop-up disappears.
			if (GetCollisionBox().Contains(GameWorld.Point))
			{
				//Console.WriteLine(prevMouse.LeftButton + " : " + curMouse.LeftButton);
				if (curMouse.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
				{
					PurchaseDwarf();
				}
			}
		}

		public void PurchaseDwarf()
		{
			if (sprite == Asset.SlaveShipFighter)
			{
				Console.WriteLine("Popup F");
				Fighter newOneF = new Fighter(new Vector2(MapObject.SlaveShipSprite.Position.X - Asset.DwarfFighterSprite.Width * 30, MapObject.SlaveShipSprite.Position.Y));
				GameWorld.NewGameObjects.Add(newOneF);
				//GameWorld.homeBase.GoldAmount -= 15;
				pickedDwarf = true;
			}
			if (sprite == Asset.SlaveShipMiner)
			{
				Console.WriteLine("Popup M");
				Miner newOneM = new Miner(new Vector2(MapObject.SlaveShipSprite.Position.X - Asset.DwarfMinerSprite.Width * 30, MapObject.SlaveShipSprite.Position.Y));
				GameWorld.NewGameObjects.Add(newOneM);
				/*GameWorld.homeBase.GoldAmount -= 15;*/
				pickedDwarf = true;
			}

			//		MouseState mouseState = Mouse.GetState();
			//if (GetCollisionBox().Contains(GameWorld.Point))
			//{
			//	if (mouseState.LeftButton == ButtonState.Pressed)
			//	{
			//		if (!pressed)
			//		{
			//			if (sprite == Asset.SlaveShipFighter)
			//			{
			//				Console.WriteLine("Popup F");
			//				Fighter newOneF = new Fighter(new Vector2(MapObject.SlaveShipSprite.Position.X - Asset.DwarfFighterSprite.Width * 30, MapObject.SlaveShipSprite.Position.Y));
			//				GameWorld.NewGameObjects.Add(newOneF);
			//				//GameWorld.homeBase.GoldAmount -= 15;
			//				pickedDwarf = true;
			//				pressed = true;
			//			}
			//			else if (sprite == Asset.SlaveShipMiner)
			//			{
			//				Console.WriteLine("Popup M");
			//				Miner newOneM = new Miner(new Vector2(MapObject.SlaveShipSprite.Position.X - Asset.DwarfMinerSprite.Width * 30, MapObject.SlaveShipSprite.Position.Y));
			//				GameWorld.NewGameObjects.Add(newOneM);
			//				/*GameWorld.homeBase.GoldAmount -= 15;*/
			//				pickedDwarf = true;
			//				pressed = true;
			//			}
			//		}
			//	}
			//	else
			//	{
			//		pressed = false;
			//	}

			//}

		}
	}
}
