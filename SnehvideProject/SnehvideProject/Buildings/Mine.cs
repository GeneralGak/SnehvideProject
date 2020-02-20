using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{

	public class Mine : Building, IPlayerUnit
	{

		private bool emptyMine = false;
		private bool hasBeenUpgraded = false;
		private bool closeMine = false;
		private int gold;
		private int minerCount;
		private int XP;
		private static int maxCapacity = 2;
		private Semaphore mineCapacity = new Semaphore(0, maxCapacity);



		public Mine(Vector2 position)
		{
			this.Position = position;
			Initialise();
		}

		public void Initialise()
		{
			mineCapacity.Release(maxCapacity);
			ChangeSprite(Asset.MineSprite);
		}

		public int Gold
		{
			get { return gold; }
		}

		/// <summary>
		/// Adds threads to the ValueIncreaser class (Used to test functionality)
		/// </summary>
		public void UpgradeThread()
		{
			// TODO: Add a thread for every miner that enters the Mine.
			emptyMine = false;
			Thread UpgradeMiniThread = new Thread(CanUpgrade);
			UpgradeMiniThread.IsBackground = true;
			UpgradeMiniThread.Start();
		}

		/// <summary>
		/// Adds gold to the player by using threads as counters
		/// </summary>
		public void MineGold()
		{
			if (closeMine == false)
			{
				mineCapacity.WaitOne();
				Console.WriteLine("Enter Mine");
				// counts up gold and XP
				//while (emptyMine == false)
				//{
				//	Thread.Sleep(3000);
				//	gold += 10;
				//	XP++;
				//	Console.WriteLine(gold);
				//}

				Thread.Sleep(6000);
				// TODO: Tilføj funktion til at giver mineren guld
				XP++;
				//gold = 10;
				mineCapacity.Release();
				Console.WriteLine("Leave Mine");
			}
			else
			{
				Thread.Sleep(6002);
				mineCapacity.WaitOne();
				Console.WriteLine("Enter Mine");
				// counts up gold and XP
				//while (emptyMine == false)
				//{
				//	Thread.Sleep(3000);
				//	gold += 10;
				//	XP++;
				//	Console.WriteLine(gold);
				//}

				Thread.Sleep(6000);
				// TODO: Tilføj funktion til at giver mineren guld
				XP++;
				mineCapacity.Release();
				Console.WriteLine("Leave Mine"); // ???
			}

			// TODO: Add the functionality that adds value to the Treasury. (Or something else to keep track for gold)
		}

		public void CanUpgrade()
		{
			while(hasBeenUpgraded == false)
			{
				if (XP >= 10 && hasBeenUpgraded == false)
				{
					Upgrade();
					hasBeenUpgraded = true;
				}
			}
		}

		/// <summary>
		/// Upgrades the mine to have more miners
		/// </summary>
		public void Upgrade()
		{
			closeMine = true;
			Thread.Sleep(6100);
			maxCapacity++;
			mineCapacity = new Semaphore(maxCapacity, maxCapacity);
			//mineCapacity.Release(maxCapacity);
			Console.WriteLine("Mine have been upgraded");
			haveBeenUpgraded = true;
			closeMine = false;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

	}
}
