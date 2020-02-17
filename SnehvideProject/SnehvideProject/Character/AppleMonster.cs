using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnehvideProject
{
	class AppleMonster : Character
	{
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
				if (gameObject != null && gameObject is IPlayerUnits)
				{
					// Player is not close enough
					if ((this.position.X + 600) < (gameObject.Position.X) || (this.position.X - 600) > (gameObject.Position.X))
					{
						return false;
					}

					// Player is not close enough
					if ((this.position.Y + 600) < (gameObject.Position.Y) || (this.position.Y - 600) > (gameObject.Position.Y))
					{
						return false;
					}
				}
			}

			// Player is close enough
			return true;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			CanSeeDwarf();
		}

	}
}
