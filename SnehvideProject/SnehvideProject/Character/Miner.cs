using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class Miner : Dwarf, IPlayerUnit
    {
        // FIELDS
        private float targetDistanceX;
        private float targetDistanceY;
        private GameObject collisionObject;
        private bool carryingGold;
        private bool isSelected;
        private bool isInMine = false;
        private bool isInHB = false;
        private bool moveTowardsMine;
        private bool moveTowardsHB;
        private int goldAmount;
        private int orderGvn; // 0 = mine gold, 1 = attack

        // METHODS
        public Miner(Vector2 position)
        {
            this.position = position;
            this.Faction = Faction.Player;
            ChangeSprite(Asset.DwarfMinerSprite);
            health = 5;
            movementSpeed = 200;
            orderGvn = 0;
            isAlive = true;
            drawLayer = 0.5f;
            Thread minerThread = new Thread(() => SwitchAction());
            minerThread.IsBackground = true;
            minerThread.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move(gameTime);
        }

        public override void Die()
        {
                GameWorld.RemoveGameObject(this);
        }

        public override void OnTakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void CheckCollision(GameObject otherObject)
        {
            base.CheckCollision(otherObject);
            /// This checks to see if the field collisionObject has been set to an instance of an object. 
			/// If collisionObject is not null that means the miner has just collided with an object fx the mine of homebase.
			if (collisionObject != null)
            {
                /// If the Collisionbox for the miner no longer intersects with the Collisionbox of collisionObject
                /// the collisionObject is set to null.
                if (!GetCollisionBox().Intersects(otherObject.GetCollisionBox()) && otherObject == collisionObject)
                {
                    collisionObject = null;
                }
            }
        }

        public override void OnCollision(GameObject otherObject)
        {
            base.OnCollision(otherObject);
            if (otherObject is Mine)
            {
                collisionObject = GameWorld.mine;
                moveTowardsMine = false;
            }

            if (otherObject is HomeBase)
            {
                collisionObject = GameWorld.homeBase;
                moveTowardsHB = false;
            }

            if (collisionObject == GameWorld.mine)
            {
                isInMine = true;
            }

            else if (collisionObject == GameWorld.homeBase)
            {
                isInHB = true;
            }

            else if (collisionObject == null)
            {
                isInMine = false;
                isInHB = false;
            }
        }

        public void SwitchAction()
        {
            while (isAlive)
            {
                if (orderGvn == 0) // Order given is to mine. The mining loop is started
                {
                    if (!carryingGold && !isInMine) // If a miner is not carrying gold and is not in the mine he must go towards the mine
                    {
                        moveTowardsMine = true;
                        moveTowardsHB = false;
                    }
                    if (carryingGold && !isInHB) // If a miner is carrying gold and is not in home base he should go twards home base
                    {
                        moveTowardsMine = false;
                        moveTowardsHB = true;
                    }
                    if (isInMine && !carryingGold) // If a miner is in the mine and isn't carrying gold he should mine
                    {
                        MineGold();
                    }
                    if (carryingGold && isInHB) // If a miner is in the home base and carrying gold he should deliver it
                    {
                        DeliverGold();
                    }
                }
                
            }
        }

        public override void Direction()
        {
            if (moveTowardsMine)
            {
                targetDistanceX = GameWorld.mine.Position.X - position.X;
                targetDistanceY = GameWorld.mine.Position.Y - position.Y;
            }
            else if (moveTowardsHB)
            {
                targetDistanceX = GameWorld.homeBase.Position.X - position.X;
                targetDistanceY = GameWorld.homeBase.Position.Y - position.Y;
            }
            else
            {
                targetDistanceX = 0;
                targetDistanceY = 0;
            }

            if (targetDistanceX < -sprite.Width / 2)
            {
                velocity.X = -1f;
            }
            else if (targetDistanceX > sprite.Width / 2)
            {
                velocity.X = 1f;
            }
            else if (targetDistanceX == 0)
            {
                velocity.X = 0f;
            }

            if (targetDistanceY < -sprite.Height / 2)
            {
                velocity.Y = -1f;
            }
            else if (targetDistanceY > sprite.Height / 2)
            {
                velocity.Y = 1f;
            }
            else if (targetDistanceY == 0)
            {
                velocity.Y = 0f;
            }

            if (velocity != Vector2.Zero)
            {
                // Ensures that the player sprite doesn't move faster if they hold down two move keys at the same time.
                velocity.Normalize();
            }
        }

        public override void Move(GameTime gameTime)
        {
            Direction();
            base.Move(gameTime);
        }


        private void MineGold()
        {
            GameWorld.mine.MineGold();
            goldAmount += 10;
            carryingGold = true;
        }

        public void DeliverGold()
        {
            GameWorld.homeBase.DeliverGold();
            GameWorld.homeBase.GoldAmount += goldAmount;
            goldAmount = 0;
            carryingGold = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isInMine || isInHB)
            {

            }
            else
            {
                base.Draw(spriteBatch);
            }

        }
    }

}
