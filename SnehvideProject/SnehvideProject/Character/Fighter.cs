using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class Fighter : Dwarf, IPlayerUnit
    {

		public Fighter(Vector2 position)
		{
			ChangeSprite(Assets.DwarfFighterSprite);
		}
    }
}
