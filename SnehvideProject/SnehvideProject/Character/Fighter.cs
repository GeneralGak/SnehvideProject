using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class Fighter : Dwarf, IPlayerUnit, ICanTakeDamage
    {

		Barrack touchedBarrack;
		private bool isInBarrack = false;
		private int orderNumber = 0;


		public int OrderNumber
		{
			get { return orderNumber; }
			set { orderNumber = value; }
		}

		public bool IsInBarrack
		{
			get { return isInBarrack; }
			set { isInBarrack = value; }
		}


        public Fighter(Vector2 position)
        {
            this.Position = position;
            this.Faction = Faction.Player;
            ChangeSprite(Asset.DwarfFighterSprite);
            this.damage = 2;
            this.health = 10;
            this.movementSpeed = 300;
            drawLayer = 0.5f;

			this.IsAlive = true;
			Thread dwarfThread = new Thread(SwithAction);
			dwarfThread.IsBackground = true;
			dwarfThread.Start();
			drawLayer = 0.02f;
		}

        public override void Die()
        {
            GameWorld.RemoveGameObject(this);
        }

        public override void Direction()
        {
            throw new NotImplementedException();
        }

        public override void OnTakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(GameObject otherObject)
        {
            base.OnCollision(otherObject);

			Barrack barrack = otherObject as Barrack;

			//if (barrack != null)
			//{
			//	isInBarrack = true;
			//	//touchedBarrack = otherObject as Barrack;
			//	touchedBarrack = barrack;
			//}

			//if(otherObject is Barrack)
			//{
			//	isInBarrack = true;
			//	touchedBarrack = otherObject as Barrack;
			//}
		}


        public override void CheckCollision(GameObject otherObject)
        {
            base.CheckCollision(otherObject);

            /// This checks to see if the field collisionObject has been set to an instance of an object.
            /// If collisionObject is not null that means the miner has just collided with an object fx the mine of homebase.

            if (!GetCollisionBox().Intersects(otherObject.GetCollisionBox()))
            {
                OnCollision(otherObject);
            }
            else if (otherObject == null && isInBarrack == true)
            {
                isInBarrack = false;
            }

        }
		public void SwithAction()
		{
			while(isAlive == true)
			{
				if(orderNumber == 0)
				{
					this.Velocity = Vector2.Zero;
				}
				if (orderNumber == 1 && isInBarrack == true)
				{
					MoveDirection(Vector2.Zero);
					GameWorld.barrack.TrainDwarf();
				}
				if (orderNumber == 1 && isInBarrack == false)
				{
					MoveDirection(GameWorld.barrack.Position);
					Console.WriteLine($"Fighter position: {Position}");
				}
				if(orderNumber == 2)
				{
					MoveDirection(GameWorld.homeBase.Position);
					Console.WriteLine("");
				}
			}
		}

		public Vector2 MoveDirection(Vector2 targetPosition)
		{

			if(targetPosition != Vector2.Zero)
			{
				this.Velocity = targetPosition - this.position;
			}
			else
			{
				Velocity = Vector2.Zero;
			}

			if (velocity != Vector2.Zero)
			{
				velocity.Normalize();
			}

			return this.Velocity;
		}

		public void CompletedTraining()
		{
			// TODO: think about putting a limit on the training amount.
			Damage += 2;
			Health += 4;
			Console.WriteLine("Training done.");
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			//================================
			// test
			if (KeyboardAndMouse.HasBeenPressed(Keys.F))
			{
				Console.WriteLine("PRESSED BUTTON");
				OrderNumber = 1;
			}

			Move(gameTime);
		}
	}

}
