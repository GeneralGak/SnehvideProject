using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class HomeBase : Building, IPlayerUnit
    {

		public HomeBase(Vector2 position)
		{
			this.Position = position;
			ChangeSprite(Asset.MainBase);
		}

    }
}
