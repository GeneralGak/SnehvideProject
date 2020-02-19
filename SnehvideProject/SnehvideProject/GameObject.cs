﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{

	public enum Faction { Player, Enemy, Neutral };

	public abstract class GameObject
    {
		// FIELDS
		protected Faction faction = Faction.Neutral;
        protected Vector2 position;
        protected float drawLayer = 0.01f;
        protected float rotation;
        protected float size = 1;
        protected string name; // Behøver vi name?
        protected Vector2 origin;
        protected Texture2D sprite;
        protected Texture2D[] sprites;
        protected bool spriteFlippedX;
        protected bool spriteFlippedY;
        protected bool isHidden;

        //PROPERTIES

        /// <summary>
        /// Position Property
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        //public float PositionY
        //{
        //	get { return position.Y; }
        //	set { position.Y = value; }
        //}

        //public float PositionX
        //{
        //	get { return position.X; }
        //	set { position.X = value; }
        //}

        public bool SpriteFlippedX
        {
            get { return spriteFlippedX; }
            set { spriteFlippedX = value; }
        }

        public bool SpriteFlippedY
        {
            get { return spriteFlippedY; }
            set { spriteFlippedY = value; }
        }

        public Texture2D Sprite
        {
            get { return sprite; }
        }

		public Faction Faction
		{
			get { return faction; }
			set { faction = value; }
		}

		public float Size { get => size; set => size = value; }
        public bool IsHidden { get; set; }

        /// <summary>
        /// Empty GameObject Constructor
        /// </summary>
        public GameObject() { }

        /// <summary>
        /// GameObject constructor with 1 parameter for position
        /// </summary>
        /// <param name="position"></param>
        public GameObject(Vector2 position)
        {
            this.position = position;
        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        /// <summary>
        /// Runs every frame
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }

		/// <summary>
		/// Runs on collision with other objects
		/// </summary>
		/// <param name="otherObject"></param>
		public abstract void OnCollision(GameObject otherObject);

		/// <summary>
		/// Draw object sprite
		/// </summary>
		/// <param name="spriteBatch"></param>
		public virtual void Draw(SpriteBatch spriteBatch)
		{

			if (sprite != null && !IsHidden)
			{
				SpriteEffects effect = SpriteEffects.None;
				if (spriteFlippedX)
				{
					effect = SpriteEffects.FlipVertically;
				}
				else if (spriteFlippedY)
				{
					effect = SpriteEffects.FlipHorizontally;

				}
				spriteBatch.Draw(sprite, position, null, Color.White, MathHelper.ToRadians(rotation), origin, size, effect, drawLayer);
			}
		}

		/// <summary>
		/// Create the collision box
		/// </summary>
		/// <returns></returns>
		public virtual Rectangle GetCollisionBox()
		{
			if (sprite != null)
			{
				return new Rectangle((int)position.X - (int)origin.X, (int)position.Y - (int)origin.Y, sprite.Width, sprite.Height);
			}
			else
			{
				return new Rectangle();
			}
		}

		/// <summary>
		/// Check for collisions with other objects
		/// </summary>
		/// <param name="otherObject"></param>
		public virtual void CheckCollision(GameObject otherObject)
		{
			if (GetCollisionBox().Intersects(otherObject.GetCollisionBox()))
			{
				OnCollision(otherObject);
			}
		}

		// Rotates a sprite towards a location
		public void LookAt(Vector2 positionToLookAt)
		{
			rotation = Helper.CalculateAngleBetweenPositions(this.position, positionToLookAt);
		}

		// sets sprites for GameObjects and defines the origin point. Can also be used to change gameObjects sprite in run time
		public void ChangeSprite(Texture2D sprite)
		{
			if (sprite != null)
			{
				this.sprite = sprite;
				this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
			}
		}

		// Borrowed from another projekt
		public Vector2 ForwardVector
		{
			get
			{
				return new Vector2(
					Helper.Cos(this.rotation),
					Helper.Sin(this.rotation)
				);
			}
		}

	}
}
