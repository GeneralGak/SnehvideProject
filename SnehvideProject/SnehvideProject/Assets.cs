using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
	public static class Assets
	{
		public static Texture2D appleMonsterSprite;
		public static Texture2D dwarfMinerSprite;
		public static Texture2D dwarfFighterSprite;
		public static Texture2D friendlyBarrackSprite;
		public static Texture2D friendlyMineSprite;

		// Map objects and background tiles.
		public static Texture2D grassSprite;
		public static Texture2D groundSprite;
		public static Texture2D waterSprite;
		public static Texture2D appletreeSprite;
		public static Texture2D treeSprite;

        public static void LoadContent(ContentManager content)
		{
            grassSprite = content.Load<Texture2D> ("tile_02");
			groundSprite = content.Load<Texture2D> ("tile_06");
            waterSprite = content.Load<Texture2D>("tile_19");
            appletreeSprite = content.Load<Texture2D>("Appletree");
            treeSprite = content.Load<Texture2D>("Tree");
		}
	}
}
