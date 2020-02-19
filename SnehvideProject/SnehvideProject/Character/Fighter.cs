﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class Fighter : Dwarf, IPlayerUnit, ICanTakeDamage
    {

		public Fighter(Vector2 position)
		{
			this.Position = position;
			this.Faction = Faction.Player;
			ChangeSprite(Assets.DwarfFighterSprite);
            health = 10;
            movementSpeed = 300;
		}

        public override void Die()
        {
            GameWorld.RemoveGameObject(this);
        }
    }
}
