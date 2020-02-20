﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
    public class Fighter : Dwarf, IPlayerUnit, ICanTakeDamage
    {

        Barrack touchedBarrack;
        private bool isInBarrack = false;
        private int ordreNumber = 0;

        public Fighter(Vector2 position)
        {
            this.Position = position;
            this.Faction = Faction.Player;
            ChangeSprite(Asset.DwarfFighterSprite);
            this.damage = 2;
            this.health = 10;
            this.movementSpeed = 300;
            Thread dwarfThread = new Thread(SwithAction);
            dwarfThread.IsBackground = true;
            dwarfThread.Start();
        }

        public override void Die()
        {
            GameWorld.RemoveGameObject(this);
        }

        public override void Direction()
        {
            throw new NotImplementedException();
        }

        public override void OnTakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(GameObject otherObject)
        {
            base.OnCollision(otherObject);

            //Barrack barrack = otherObject as Barrack;

            if (otherObject is Barrack)
            {
                isInBarrack = true;
                touchedBarrack = otherObject as Barrack;
                //touchedBarrack = barrack;
            }
        }

        public override void CheckCollision(GameObject otherObject)
        {
            base.CheckCollision(otherObject);

            /// This checks to see if the field collisionObject has been set to an instance of an object. 
            /// If collisionObject is not null that means the miner has just collided with an object fx the mine of homebase.

            if (!GetCollisionBox().Intersects(otherObject.GetCollisionBox()))
            {
                OnCollision(otherObject);
            }
            else if (otherObject == null && isInBarrack == true)
            {
                isInBarrack = false;
            }

        }

        public void SwithAction()
        {
            while (isAlive == true)
            {
                if (ordreNumber == 0)
                {
                    this.Velocity = Vector2.Zero;
                }
                if (ordreNumber == 1 && isInBarrack == true)
                {
                    touchedBarrack.TrainDwarf();
                }
                if (ordreNumber == 1 && isInBarrack == false)
                {
                    this.Velocity = GameWorld.barrack.Position - this.position;
                }
            }
        }

        public void CompletedTraining()
        {
            // TODO: think about putting a limit on the training amount.
            Damage += 2;
            Health += 4;
        }
    }
}
