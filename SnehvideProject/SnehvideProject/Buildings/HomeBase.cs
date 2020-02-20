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
		private int minerCount;

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
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			Console.WriteLine(goldAmount);
		}

		public void DeliverGold()
		{
			homeBaseCapacity.WaitOne();
			Console.WriteLine("Enter Home Base");
			minerCount++;
			Thread.Sleep(3000);
			homeBaseCapacity.Release();
			Console.WriteLine("Leave Home Base");
			minerCount--;
		}
	}
}
