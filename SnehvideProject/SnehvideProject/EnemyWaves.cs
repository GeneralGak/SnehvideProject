using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
	public static class EnemyWaves
	{
		
		private static int timer = 10000;

		public static void StartTimer()
		{
			Thread ThreadCounter = new Thread(TimerCount);
			ThreadCounter.IsBackground = true;
			ThreadCounter.Start();
		}

		public static void TimerCount()
		{
			while(true)
			{
				Thread.Sleep(timer);
				Console.WriteLine("Sleep over");
				foreach(GameObject gameObject in GameWorld.GameObjects)
				{
					if(gameObject is AppleMonster)
					{
						AppleMonster appleMonster = gameObject as AppleMonster;
						SendWave(appleMonster);
					}
				}
				if(timer >= 25000)
				{
					timer -= 6000;
				}
			}
		}

		public static void SendWave(AppleMonster monster)
		{
			Console.WriteLine("Send Wave");
			monster.UnitAttack = true;
		}

	}
}
