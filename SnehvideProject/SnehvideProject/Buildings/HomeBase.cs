using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
	public class HomeBase : Building, IPlayerUnit
	{
		// FIELDS 
		private int goldAmount;
		private static int maxCapacity = 2;
		private Semaphore homeBaseCapacity = new Semaphore(0, maxCapacity);

		// PROPERTIES

		public int GoldAmount
		{
			get { return goldAmount; }
			set { goldAmount = value; }
		}

		// METHODS

		public HomeBase(Vector2 position)
		{
			this.Position = position;
			ChangeSprite(Asset.MainBase);
			homeBaseCapacity.Release(2);
			drawLayer = 0.04f;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public void DeliverGold()
		{
			homeBaseCapacity.WaitOne();
			Console.WriteLine("Enter Home Base");
			Thread.Sleep(3000);
			homeBaseCapacity.Release();
			Console.WriteLine("Leave Home Base");
		}
	}
}
