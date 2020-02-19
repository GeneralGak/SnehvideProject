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
        private int goldAmount;
        private int orderGvn; // 0 = mine gold, 1 = attack

        // METHODS

        public override void OnCollision(GameObject otherObject)
        {
            if (otherObject is Mine)
            {
                isInMine = true;
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
