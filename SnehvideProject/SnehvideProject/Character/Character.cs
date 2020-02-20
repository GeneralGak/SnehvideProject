using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnehvideProject
{

    public abstract class Character : GameObject
    {

		/// <summary>
		///Default: 500
		/// </summary>
		protected float movementSpeed = 500;
		/// <summary>
		/// Default: 1
		/// </summary>
		protected int health = 1;
		/// <summary>
		/// Default: true
		/// </summary>
		protected bool isAlive = true;

		protected Vector2 velocity;
		protected Vector2 positionPreMove;
		protected float invinsibilityTimer;
		protected float attackRange;
		protected float damage;
		protected bool takeDamage;



		public Vector2 Velocity
		{
			get { return velocity; }
			set { velocity = value; }
		}

		public int Health
		{
			get { return health; }
			set
			{
				health = value;
				if (health < 0)
				{
					health = 0;
				}
			}
		}

		public bool TakeDamage
		{
			get { return takeDamage; }
			set { takeDamage = value; }
		}

		public bool IsAlive
		{
			get { return isAlive; }
			set { isAlive = value; }
		}

		public float Damage
		{
			get { return damage; }
			set { damage = value; }
		}


		/// <summary>
		/// Character dies
		/// </summary>
		public virtual void Die()
		{

		}

		/// <summary>
		/// Character attacks
		/// </summary>
		public abstract void Attack(GameObject gameObject);

		/// <summary>
		/// Update health of character
		/// </summary>
		/// <param name="damage">Damage the character loses. Negative numbers give the character health.</param>
		/// <returns></returns>
		public virtual int UpdateHealth(int damage)
		{
			if (damage > 0)
			{
				Health -= damage;
			}
			else
			{
				Health += Math.Abs(damage);
			}

			//HP 0, die
			if (Health == 0)
			{
				Die();
			}
			return Health;
		}

		public abstract void Direction();

		public virtual void Move(GameTime gameTime)
		{
			//deltaTime based on gameTime
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			//Moves the player based on velocity, speed, and deltaTime
			position += ((velocity * movementSpeed) * deltaTime);
		}

		public override void Update(GameTime gameTime)
		{

			positionPreMove = position;
			foreach(GameObject gameObject in GameWorld.GameObjects)
			{
				CanAttack(gameObject);
			}

		}

		public override void OnCollision(GameObject otherObject)
		{



		}

		public abstract void OnTakeDamage();

		/// <summary>
		/// Returns true when a gameObject is close enough
		/// </summary>
		/// <param name="gameObject"></param>
		/// <returns></returns>

		public bool CanAttack(GameObject gameObject)
		{

			if (gameObject != null)
			{
				// Character is not close enough
				if ((this.position.X + attackRange) < (gameObject.Position.X) || (this.position.X - attackRange) > (gameObject.Position.X))
				{
					return false;
				}

				// Character is not close enough
				if ((this.position.Y + attackRange) < (gameObject.Position.Y) || (this.position.Y - attackRange) > (gameObject.Position.Y))
				{
					return false;
				}
			}
			else
			{
				return false;
			}


			// Character is close enough
			return true;
		}

	}
}
