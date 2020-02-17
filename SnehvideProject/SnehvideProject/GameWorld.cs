﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SnehvideProject
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class GameWorld : Game
	{

		// List for all the gameObjects
		public static List<GameObject> GameObjects = new List<GameObject>();

		//To get random numbers
		public static Random rng = new Random();
		//To add and remove objects in runtime
		public static List<GameObject> NewGameObjects = new List<GameObject>();
		public static List<GameObject> RemoveGameObjects = new List<GameObject>();

		public static void AddGameObject(GameObject gameObject)
		{
			NewGameObjects.Add(gameObject);
		}

		public static void RemoveGameObject(GameObject gameObject)
		{
			RemoveGameObjects.Add(gameObject);
		}

		//FIELDS
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private static Vector2 scrSize;
		private static float scrScale;
        private static float tileSize;

        private Map gameMap;

		// PROPERTIES

		/// <summary>
		/// Used for accessing screen size elsewhere in the code
		/// </summary>
		public static Vector2 ScrSize
		{
			get { return scrSize; }
		}

		/// <summary>
		/// Used for accessing scaling elsewhere in the code
		/// </summary>
		public static float ScrScale
		{
			get { return scrScale; }
		}

        public static float TileSize { get => tileSize; set => tileSize = value; }

        public GameWorld()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			// Sets screen width and height in a vector
			scrSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            tileSize = 64 * scrScale;
			// Sets screen scale
			scrScale = ((1f / 1920f) * GraphicsDevice.DisplayMode.Width);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            gameMap = new Map();

			Assets.LoadContent(Content);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			foreach (GameObject gameObject in GameObjects)
			{
				//Update all objects in active room
				gameObject.Update(gameTime);
				foreach (GameObject other in GameObjects)
				{
					gameObject.CheckCollision(other);
				}
			}

			//Add new objects to rooms
			foreach (GameObject gameObject in NewGameObjects)
			{
				GameObjects.Add(gameObject);
			}
			NewGameObjects.Clear();
			//Remove gameobjects from rooms
			foreach (GameObject gameObject in RemoveGameObjects)
			{
				if (gameObject != null)
				{
					GameObjects.Add(gameObject);
				}
				else
				{
					GameObjects.Remove(gameObject);
				}
			}
			RemoveGameObjects.Clear();

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, Camera.Transform);

			// TODO: Add your drawing code here

			//Draws all objects in active room
			foreach (GameObject gameObject in GameObjects)
			{
				//Update all objects in active room
				gameObject.Draw(spriteBatch);
#if DEBUG
				DrawCollisionBox(gameObject);
#endif
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void DrawCollisionBox(GameObject gameObject)
		{

		}
	}
}