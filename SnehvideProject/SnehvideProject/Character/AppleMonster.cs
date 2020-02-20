using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnehvideProject
{
	public class AppleMonster : Character, ICanTakeDamage
	{

		private bool unitAttack = false;
		private bool canSeeUnit;


		public bool UnitAttack
		{
			get { return unitAttack; }
			set { unitAttack = value; }
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="position"></param>
		public AppleMonster(Vector2 position)
		{
			this.Position = position;
			attackRange = 150;
			this.movementSpeed = 350;
			this.Faction = Faction.Enemy;
			velocity = Vector2.Zero;
			ChangeSprite(Asset.AppleMonsterSprite);
		}

		/// <summary>
		/// Attack a gameObject when it is whitin a certain distance.
		/// </summary>
		/// <param name="gameObject"></param>
		public override void Attack(GameObject gameObject)
		{
			if(CanAttack(gameObject) == true && gameObject.Faction != this.Faction && gameObject is ICanTakeDamage)
			{
				Console.WriteLine("Can Attack Dwarf");
				velocity = Vector2.Zero;
			}
		}

		public override void Die()
		{
			throw new NotImplementedException();
		}

		public override void OnTakeDamage()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns true when a GameObject is whitin a certain distance.
		/// </summary>
		/// <param name="gameObject"></param>
		/// <returns></returns>
		public bool CanSeeUnit(GameObject gameObject)
		{

			if(gameObject != null)
			{
				if ((this.position.X + 500) < (gameObject.Position.X) || (this.position.X - 500) > (gameObject.Position.X))
				{

					return false;

				}


				if ((this.position.Y + 500) < (gameObject.Position.Y) || (this.position.Y - 500) > (gameObject.Position.Y))
				{

					return false;
				}
			}
			else
			{
				return false;
			}

			if(gameObject.Faction != this.Faction && gameObject is ICanTakeDamage)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Update(GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState();
			if (GetCollisionBox().Contains(GameWorld.Point))
			{
				Console.WriteLine("Contains point");
			}
			base.Update(gameTime);
			foreach(GameObject gameObject in GameWorld.GameObjects)
			{
				if (unitAttack == true)
				{
					if (canSeeUnit == true && GameWorld.dwarf is IPlayerUnit)
					{
						Console.WriteLine("Can see Dwarf");
						this.Velocity = GameWorld.dwarf.Position - this.position;
					}
					else
					{
						this.Velocity = GameWorld.homeBase.Position - this.position;
					}
				}

				Attack(gameObject);
			}

			// Makes appleMonster change direction when statement is met.


			if (velocity != Vector2.Zero)
			{
				velocity.Normalize();
			}

			Move(gameTime);
		}

		public override void Direction()
		{
			throw new NotImplementedException();
		}
	}
}
