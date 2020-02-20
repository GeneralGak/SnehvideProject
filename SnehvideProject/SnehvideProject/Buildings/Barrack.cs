using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class Barrack : Building, IPlayerUnit
    {

		Fighter toughedFighter;
		static readonly object lockObject = new object();


		public Barrack(Vector2 position)
		{
			this.Position = position;
			ChangeSprite(Asset.BarrackSprite);
		}


		public void TrainDwarf()
		{
			lock(lockObject)
			{
				Console.WriteLine("Start training");
				Thread.Sleep(3000);
				toughedFighter.CompletedTraining();
				toughedFighter.OrderNumber = 2;
				Console.WriteLine("Leave training");

			}
		}

		public override void CheckCollision(GameObject otherObject)
		{
			base.CheckCollision(otherObject);

			//Regular collision with objects
			if (GetCollisionBox().Intersects(otherObject.GetCollisionBox()))
			{
				OnCollision(otherObject);
			}

			else if (toughedFighter != null && otherObject == toughedFighter)
			{
				// fighter is no longer touching Barrack
				toughedFighter = null;
			}
		}

		public override void OnCollision(GameObject otherObject)
		{
			base.OnCollision(otherObject);

			Fighter fighter = otherObject as Fighter;

			if(otherObject is Fighter)
			{
				toughedFighter = otherObject as Fighter;
				toughedFighter.IsInBarrack = true;
			}
		}

	}
}
