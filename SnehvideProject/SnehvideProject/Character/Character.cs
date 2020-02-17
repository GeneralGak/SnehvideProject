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
		protected bool takeDamage;


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

		/// <summary>
		/// Character dies
		/// </summary>
		public abstract void Die();

		/// <summary>
		/// Character attacks
		/// </summary>
		public abstract void Attack();

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

			OnTakeDamage();
			

			return Health;
		}

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
			CanAttack();

		}

		public override void OnCollision(GameObject otherObject)
		{



		}

		public abstract void OnTakeDamage();

		public bool CanAttack()
		{
			foreach (GameObject gameObject in GameWorld.GameObjects)
			{
				if (gameObject != null && gameObject is IPlayerUnit)
				{
					// Player is not close enough
					if ((this.position.X + attackRange) < (gameObject.Position.X) || (this.position.X - attackRange) > (gameObject.Position.X))
					{
						return false;
					}

					// Player is not close enough
					if ((this.position.Y + attackRange) < (gameObject.Position.Y) || (this.position.Y - attackRange) > (gameObject.Position.Y))
					{
						return false;
					}
				}
			}

			// Player is close enough
			Console.WriteLine("Can Attack");
			return true;
		}

	}
}
