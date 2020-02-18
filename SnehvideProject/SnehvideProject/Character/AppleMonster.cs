using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnehvideProject
{
	public class AppleMonster : Character, ICanTakeDamage
	{


		public AppleMonster(Vector2 position)
		{
			this.Position = position;
			attackRange = 150;
			this.Faction = Faction.Enemy;
			ChangeSprite(Asset.AppleMonsterSprite);
		}


		public override void Attack(GameObject gameObject)
		{
			if(CanAttack(gameObject) == true && gameObject.Faction != this.Faction && gameObject is ICanTakeDamage)
			{
				Console.WriteLine("Can Attack Dwarf");
				//velocity = Vector2.Zero;
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

		public bool CanSeeDwarf(GameObject gameObject)
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


			return true;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			foreach(GameObject gameObject in GameWorld.GameObjects)
			{
				if(CanSeeDwarf(gameObject) == true && gameObject is IPlayerUnit)
				{
					Console.WriteLine("Can see Dwarf");
					//velocity = gameObject.Position;
				}
				else
				{
					velocity = Vector2.Zero;
				}
				Attack(gameObject);
			}

			if(velocity != Vector2.Zero)
			{
				velocity.Normalize();
			}

			Move(gameTime);
		}

	}
}
