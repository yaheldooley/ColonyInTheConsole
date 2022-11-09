using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public class Scene
	{
		public int Width => _width;
		public int Height => _height;

		public char[,,] Map;

		private int _width;
		private int _height;
		private int _depth;

		public bool GameWindowVisible = false;

		public List<Entity> _entities = new List<Entity>();

		public Dictionary<int[,,], char> EntityLocations = new Dictionary<int[,,], char>();

		private char[,] _characters { get; set; }
		public Scene(int width, int height, int depth, bool loadDefault)
		{
			_width = width;
			_height = height;
			_depth = depth;
			Map = new char[_width, _height, _depth];
			if (loadDefault) DefaultScene(Map);
		}

		public void AddEntity(Entity entity)
		{
			_entities.Add(entity);
		}

		public void RemoveEntity(Entity entity)
		{
			_entities.Remove(entity);
		}

		public void Update()
		{
			foreach(Entity e in _entities)
			{
				e.Update();
			}
		}

		public char CharAt(Vector2Int pos)
		{
			return _characters[pos.Y, pos.X];
		}

		public bool IsInBounds(Vector2Int pos)
		{
			return pos.X <= (_width - 1) && pos.X >= 0 && pos.Y >= 0 && pos.Y <= (_height-1);
		}

		public void ShowVisible()
		{

		}


		public static void DefaultScene(char[,,] map)
		{
			string terrainString =	"!!||||!!!!|!|!|!|!|!|!|!|!|!|!|!|!|||!|!|!|!|!|!|!|!|!!|!!\n" +
									"!||!!|!||!||!|!||!|||||||!||!!!!!!||!|!|||||!||!|||!||!|||\n" +
									"|||!!!!!!    !!!! |!|! `` ``` ` `   ` ` ||||!|||!|||!``||`  ";

			MapFromString(terrainString, map);
		}

		public static void MapFromString(string mapString, char[,,] map)
		{
			var terrainArray = Utils.StringTo2DCharArray(mapString, new char[] { '\n' });

			Utils.JustifyContentTo3DCharArray(map, terrainArray, 0, Align.TopCenter);
			
		}
	}
}
