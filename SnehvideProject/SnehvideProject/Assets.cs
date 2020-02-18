﻿using Microsoft.Xna.Framework.Content;
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

        public static void LoadContent(ContentManager content)
		{
			GrassSprite = content.Load<Texture2D>("tile_02");
			GroundSprite = content.Load<Texture2D>("tile_06");
			WaterSprite = content.Load<Texture2D>("tile_19");
			AppletreeSprite = content.Load<Texture2D>("Appletree");
            TreeSprite = content.Load<Texture2D>("Tree");
			AppleMonsterSprite = content.Load<Texture2D>("MonsterÆble");
			DwarfFighterSprite = content.Load<Texture2D>("Dwarf Sprite Sheet");
		}

		//Maps
		public static int[,] map1Layer1 = new int[,]
		{
		 //44 * 22
				{1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         /*5*/  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		///*10*/  {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2},
		///*15*/  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2},
		//		{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2},
		//		{0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2},
		///*20*/  {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2},
		//		{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2},
		//		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2,2},
		};

		public static int[,] map1Layer2 = new int[,]
		{
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,1,1,0,1,0,1,0,0,0,1,2,0,1,0,0,1,1,2,0,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,1,0,0,1,0,0,1,1,0,1,1,0,1,0,0,1,1,0,0,1,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,0,1,1,0,0,1,0,1,0,2,0,1,1,1,0,1,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,1,1,0,1,0,1,0,0,1,1,0,2,0,0,1,0,1,1},
         /*5*/  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,2,2,0,1,0,1,2,1,0,0,1,0,2,1,0,0,1,0,1,1,0,0,0,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,1,0,0,0,1,1,1,2,0,0,1,1,1,1,0,1,0,1,0,2},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2,0,1,0,1,0,1,1,0,1,0,1,0,0,1,0,1,0,1,0,1,1,0,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,2,1,1,1,0,0,0,2,0,1,1,1,0,0,0,0,0,0,1,1,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,1,0,1,1,0,1,0,1,1,0,0,1,0,1,2,0,1,0,0,1},
		 ///*10*/ {0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,1,1,0,0,1,1,0,1,0,1,1,1,2,0,0,0,1,0,1,1,0,0,1,1,0,0,0},
			//	{0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,2,0,0,0,1,0,0,1,1,0,0,0,0,1,2,0,1,0,0,0,1,0,0,2,0,0,1,1},
			//	{0,0,1,0,1,1,1,0,0,0,2,1,1,0,1,1,0,1,1,1,0,2,2,0,1,0,1,0,0,0,0,2,0,0,1,0,0,0,0,0,0,0,0},
			//	{0,1,0,0,2,2,0,1,0,0,0,0,1,1,0,0,0,0,0,1,2,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
			//	{1,0,0,1,0,0,1,1,0,0,1,0,0,0,2,1,1,0,1,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
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
