using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnehvideProject
{
	public class AppleMonster : Character
	{


		public AppleMonster(Vector2 position)
		{
			ChangeSprite(Assets.AppleMonsterSprite);
		}


		public override void Attack()
		{
			throw new NotImplementedException();
		}

		public override void Die()
		{
			throw new NotImplementedException();
		}

		public override void OnTakeDamage()
		{
			throw new NotImplementedException();
		}

		public bool CanSeeDwarf()
		{
			foreach(GameObject gameObject in GameWorld.GameObjects)
			{

				
				if ((this.position.X + 600) > (gameObject.Position.X) || (this.position.X - 600) < (gameObject.Position.X))
				{
					if (gameObject != null && gameObject is IPlayerUnits)
					{
						Console.WriteLine("Can see Dwarf");
						return true;
					}
						
				}

				
				if ((this.position.Y + 600) > (gameObject.Position.Y) || (this.position.Y - 600) < (gameObject.Position.Y))
				{
					if (gameObject != null && gameObject is IPlayerUnits)
					{
						Console.WriteLine("Can see Dwarf");
						return true;
					}
				}
				
			}

			
			return false;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			CanSeeDwarf();
		}

	}
}
