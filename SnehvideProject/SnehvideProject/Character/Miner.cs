using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class Miner : Dwarf, IPlayerUnit
    {
        public Miner(Vector2 position)
        {
            this.position = position;
            this.Faction = Faction.Player;
            ChangeSprite(Asset.DwarfMinerSprite);
            health = 5;
            movementSpeed = 300;
        }

        public override void Die()
        {
                GameWorld.RemoveGameObject(this);
        }

        public override void OnTakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
