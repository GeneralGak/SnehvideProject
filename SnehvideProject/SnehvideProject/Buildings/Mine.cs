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
		private bool haveBeenUpgraded = false;
		private int gold;
		private int miner;
		private int XP;
		private static int maxCapacity = 2;
		Semaphore MineCapacity = new Semaphore(0, maxCapacity);

		public void EnterMine()
		{
			// TODO: Add a thread for every miner that enters the Mine.
			emptyMine = false;
			Thread DwarfMining = new Thread(ValueIncreaser);
			DwarfMining.IsBackground = true;
			DwarfMining.Start();
		}

		/// <summary>
		/// Adds gold to the player by using threads as counters
		/// </summary>
		public void ValueIncreaser()
		{
			// if there is no more space in the mine
			if (miner >= maxCapacity)
			{
				Console.WriteLine("Mine is full.");
			}
			else
			{
				MineCapacity.WaitOne();
				miner++;
				Console.WriteLine("Enter Mine");
				// counts up gold and XP
				while (emptyMine == false)
				{
					Thread.Sleep(3000);
					gold += 10;
					XP++;
					Console.WriteLine(gold);
				}
				MineCapacity.Release();
				miner--;
				Console.WriteLine("Leave Mine");
			}
						
			// TODO: Add the functionality that adds value to the Treasury. (Or something else to keep track for gold)
		}

		/// <summary>
		/// Used to relase all the miners
		/// </summary>
		public void Release()
		{
			if(miner > 0)
			{
				emptyMine = true;
			}
		}

		/// <summary>
		/// Upgrades the mine to have more miners
		/// </summary>
		public void Upgrade()
		{
			Console.WriteLine("Mine have been upgraded");
			maxCapacity++;		
		}

		public override void Update(GameTime gameTime)
		{
			if(XP >= 10 && haveBeenUpgraded == false)
			{
				Upgrade();
				EnterMine();
				haveBeenUpgraded = true;
			}
			base.Update(gameTime);
		}

	}
}
