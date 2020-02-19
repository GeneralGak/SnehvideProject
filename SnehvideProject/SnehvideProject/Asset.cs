using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnehvideProject
{
	public static class Asset
	{
		// FIELDS
		public static Texture2D AppleMonsterSprite;
		public static Texture2D DwarfMinerSprite;
		public static Texture2D DwarfFighterSprite;
		public static Texture2D FriendlyBarrackSprite;
		public static Texture2D FriendlyMineSprite;

		//Map objects and background tiles.
		public static Texture2D GrassSprite;
		public static Texture2D GroundSprite;
		public static Texture2D WaterSprite;
		public static Texture2D AppletreeSprite;
		public static Texture2D TreeSprite;
		public static Texture2D MainBase;
        public static Texture2D SlaveShip;
        public static Texture2D MouseCursorSprite;
        public static Texture2D SlaveShipPopUp;
        public static Texture2D SlaveShipFighter;
        public static Texture2D SlaveShipMiner;
		public static Texture2D BarrackSprite;

        public static Texture2D BackgroundPic;

		public static Texture2D MineSprite;


		//Map arrays
		public static int[,] map1Layer1;
		public static int[,] map1Layer2;

		/// <summary>
		/// LoadContent method for the Asset class.
		/// </summary>
		/// <param name="content"></param>
		public static void LoadContent(ContentManager content)
		{
            //Background and items
			GrassSprite = content.Load<Texture2D>("tile_02");
			GroundSprite = content.Load<Texture2D>("tile_06");
			WaterSprite = content.Load<Texture2D>("tile_19");
			AppletreeSprite = content.Load<Texture2D>("Appletree");
            TreeSprite = content.Load<Texture2D>("Tree");

            BackgroundPic = content.Load <Texture2D>("background2");

            //Enemies
			AppleMonsterSprite = content.Load<Texture2D>("MonsterÆble");
            //Dwarfs
			DwarfFighterSprite = content.Load<Texture2D>("fighter dwarf");
            DwarfMinerSprite = content.Load<Texture2D>("miner dwarf");
            //Buildings
			MainBase = content.Load<Texture2D>("fantasy-city");
            SlaveShip = content.Load<Texture2D>("MonsterÆble");
			BarrackSprite = content.Load<Texture2D>("Base_Camp");
            //Mouse
            MouseCursorSprite = content.Load<Texture2D>("mousecursor2");

            //Pop ups
            SlaveShipPopUp = content.Load<Texture2D>("Slaveship popup with text");
            SlaveShipFighter = content.Load<Texture2D>("fighter dwarf");
            SlaveShipMiner = content.Load<Texture2D>("miner dwarf");

			MineSprite = content.Load<Texture2D>("cave-entrance-pixel-art");


            map1Layer1 = new int[,]
             {

		// //44 * 22
				{4,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
  //       /*5*/  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		///*10*/  {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2},
		///*15*/  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2},
		//		{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2},
		//		{0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2},
		///*20*/  {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2},
		//		{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2,2},
		};

			map1Layer2 = new int[,]
		{
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,1,1,0,1,0,1,0,0,0,1,2,0,1,0,0,1,1,2,0,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,1,0,0,1,0,0,1,1,0,1,1,0,1,0,0,1,1,0,0,1,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,0,1,1,0,0,1,0,1,0,2,0,1,1,1,0,1,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,1,1,0,1,0,1,0,0,1,1,0,2,0,0,1,0,1,1},
         /*5*/  {0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,2,0,2,2,0,1,0,1,2,1,0,0,1,0,2,1,0,0,1,0,1,1,0,0,0,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,1,0,0,0,1,1,1,2,0,0,1,1,1,1,0,1,0,1,0,2},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2,0,1,0,1,0,1,1,0,1,0,1,0,0,1,0,1,0,1,0,1,1,0,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,2,1,1,1,0,0,0,2,0,1,1,1,0,0,0,0,0,0,1,1,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,1,0,1,1,0,1,0,1,1,0,0,1,0,1,2,0,1,0,0,1},
		 /*10*/ {0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,1,1,0,0,1,1,0,1,0,1,1,1,2,0,0,0,1,0,1,1,0,0,1,1,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,2,0,0,0,1,0,0,1,1,0,0,0,0,1,2,0,1,0,0,0,1,0,0,2,0,0,0,0},
				{0,0,1,0,1,1,1,0,0,0,2,1,1,0,1,1,0,1,1,1,0,2,2,0,1,0,1,0,0,0,0,2,0,0,1,0,0,0,0,0,3,0,0},
				{0,1,0,0,2,2,0,1,0,0,0,0,1,1,0,0,0,0,0,1,2,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
				{1,0,0,1,0,0,1,1,0,0,1,0,0,0,2,1,1,0,1,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		 ///*15*/ {0,2,1,1,0,0,1,0,0,1,0,2,0,1,1,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			//	{1,0,0,0,1,1,0,1,1,0,0,1,0,1,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			//	{1,0,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			//	{0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			//	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		 ///*20*/ {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			//	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			//	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		    };

		}

	}
}
