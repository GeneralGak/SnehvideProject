using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SnehvideProject
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class GameWorld : Game
	{
		// FIELDS

		// List for all the gameObjects
		public static List<GameObject> GameObjects = new List<GameObject>();

		//Lists to add and remove objects in runtime
		public static List<GameObject> NewGameObjects = new List<GameObject>(), RemoveGameObjects = new List<GameObject>();

		//To get random numbers
		public static Random rng = new Random();

		private static int screenWidth, screenHeight;

		
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private static Vector2 scrSize;
		private static float scrScale, tileSize;
		public static AppleMonster monster;
		public static Fighter dwarf;
		public static HomeBase homeBase;
		private MapObject gameMap;

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

		/// <summary>
		/// Used for accessing tilesize elsewhere in the code
		/// </summary>
        public static float TileSize
        {
            get { return tileSize; }
        }

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

            // Adjusts the game window to the screen resolution
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;

            // Sets screen width and height in a vector
            scrSize = new Vector2(screenWidth, screenHeight);
			// Sets screen scale
			scrScale = ((1f / 1920f) * GraphicsDevice.DisplayMode.Width);
            // Sets tilesize
            tileSize = 64 * scrScale;

			Asset.LoadContent(Content);
			gameMap = new MapObject();
			//gameMap.GenerateLevel(Asset.map1Layer1, Asset.map1Layer2, tileSize);
			Thread generateMapThread = new Thread(() => gameMap.GenerateMap(Asset.map1Layer1, Asset.map1Layer2, tileSize));
			generateMapThread.Start();

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

			// Test Monster and Dwarf
			homeBase = new HomeBase(new Vector2(100, 1000));
			monster = new AppleMonster(new Vector2(100, 100));
			dwarf = new Fighter(new Vector2(550, 550));
			GameObjects.Add(monster);
			GameObjects.Add(dwarf);
			GameObjects.Add(homeBase);
			EnemyWaves.StartTimer();

		}

		/// <summary
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
			Camera.Update();
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

			spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null, Camera.Transform);
			//spriteBatch.Begin();

			// TODO: Add your drawing code here

			//Draws all objects in active room
			foreach (GameObject gameObject in GameObjects)
			{
				//Ensures that only the objects within the screenbounds are drawn. 
				if (gameObject.Position.X <= Camera.CamPos.X + scrSize.X && gameObject.Position.Y <= Camera.CamPos.Y + scrSize.Y)
				{
					gameObject.Draw(spriteBatch);
#if DEBUG
					DrawCollisionBox(gameObject);
#endif
				}
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void DrawCollisionBox(GameObject gameObject)
		{

		}

		/// <summary>
		/// Method for adding new gameobjects while the game is running
		/// </summary>
		/// <param name="gameObject"></param>
		public static void AddGameObject(GameObject gameObject)
		{
			NewGameObjects.Add(gameObject);
		}

		/// <summary>
		/// Method for removing gameobjects while the game is running
		/// </summary>
		/// <param name="gameObject"></param>
		public static void RemoveGameObject(GameObject gameObject)
		{
			RemoveGameObjects.Add(gameObject);
		}

	}
}
