using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
	public static class Time
	{

		public static float deltaTime;
		public static float totalTime;

		public static void UpdateTimeVariables(GameTime gameTime)
		{

			deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			totalTime = (float)gameTime.TotalGameTime.TotalSeconds;

		}

	}
}
