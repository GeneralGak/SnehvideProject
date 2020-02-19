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
        // FIELDS
        private bool carryingGold;
        private bool isSelected;
        private bool isInMine = false;
        private bool isInTreasury = false;
        private int goldAmount;
        private int orderGvn; // 0 = mine gold, 1 = attack

        // METHODS
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

        public override void OnCollision(GameObject otherObject)
        {
            if (otherObject is Mine)
            {
                isInMine = true;
            }

            if(otherObject is Treasury)
            {
                isInTreasury = true;
            }
            base.OnCollision(otherObject);
        }

        public void SwitchAction()
        {
            if (orderGvn == 0 && isInMine == true)
            {

            }
        }

        public void Direction(GameObject target)
        {
        }

        public override void Move(GameTime gameTime)
        {
            base.Move(gameTime);
        }

        public void MineGold()
        {

        }

        public void Wait()
        {

        }

        public void DeliverGold()
        {

        }

    }

}
