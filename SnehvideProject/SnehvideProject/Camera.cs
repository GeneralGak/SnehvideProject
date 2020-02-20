using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
	static class Camera
	{
		// FIELDS
		//private static KeyboardState keyState = Keyboard.GetState();
		private static Vector2 velocity;
		public static Vector2 CamPosStart = new Vector2(0 + (GameWorld.ScrSize.X / 2), 0 + (GameWorld.ScrSize.Y / 2));
		public static Vector2 CamPos = CamPosStart;
		private static float speed = 10/*, previousScrollValue*/;
		public static float CamZoom = 1;

		// METHODS

		/// <summary>
		/// Transform accessed by GameWorld for displaying objects at translated position
		/// </summary>
		static public Matrix Transform { get; private set; }

		/// <summary>
		/// Updates camera transform
		/// </summary>
		/// <param name="player">Player reference</param>
		static public void Update()
		{
			HandleInput();
			Transform = Matrix.CreateTranslation(new Vector3(-CamPos, 0)) *
				Matrix.CreateScale(new Vector3(CamZoom, CamZoom, 0)) *
				Matrix.CreateTranslation(GameWorld.ScrSize.X / 2, GameWorld.ScrSize.Y / 2, 0);
			//Console.WriteLine(CamPos + " " + speed);
		}

		/// <summary>
		/// Handles input from the user. Input includes moving the camera and camerazoom.
		/// </summary>
		private static void HandleInput()
		{
			KeyboardState keyState = KeyboardAndMouse.GetState();
			velocity = Vector2.Zero;

			if (keyState.IsKeyDown(Keys.W) && CamPos.Y > 0 + (GameWorld.ScrSize.Y / 2)) // Up
			{
				velocity.Y -= 1;
			}

			if (keyState.IsKeyDown(Keys.S) && CamPos.Y < 0 + Asset.BackgroundPic.Height - GameWorld.ScrSize.Y / 2) // Down
			{
				velocity.Y += 1;
			}

			if (keyState.IsKeyDown(Keys.A) && CamPos.X > 0 + (GameWorld.ScrSize.X / 2)) // Left
			{
				velocity.X -= 1;
			}

			if (keyState.IsKeyDown(Keys.D) && CamPos.X < 0 + Asset.BackgroundPic.Width - GameWorld.ScrSize.X / 2) // Right
			{
				velocity.X += 1;
			}

			//if (keyState.IsKeyDown(Keys.E)) // Zoom in
			//{
			//	CamZoom += 0.05f * CamZoom; // value * CamZoom to negate warping effect
			//}
			//else if (GameWorld.Mousestate.ScrollWheelValue > previousScrollValue)
			//{
			//    CamZoom += 0.05f * CamZoom * 5;
			//}
			//if (keyState.IsKeyDown(Keys.Q)) // Zoom out
			//{
			//	CamZoom -= 0.05f * CamZoom;
			//}
			//else if (GameWorld.Mousestate.ScrollWheelValue < previousScrollValue)
			//{
			//    CamZoom -= 0.05f * CamZoom * 5;
			//}

			// Changes cameraposition based on velocity multiplied by speed. Speed is divided by CamZoom to avoid slowing down when zooming in
			// or speeding up when zooming out.
			CamPos += velocity * speed / CamZoom; ;

			//previousScrollValue = GameWorld.Mousestate.ScrollWheelValue;
		}
	}
}
