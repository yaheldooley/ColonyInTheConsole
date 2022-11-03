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

		private int _width;
		private int _height;

		

		private List<Entity> _entities = new List<Entity>();
		private char[,] _characters { get; set; }
		public Scene(int width, int height)
		{
			_width = width;
			_height = height;
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
			
		}

		public char CharAt(Vector2Int pos)
		{
			return _characters[pos.Y, pos.X];
		}

		public bool IsInBounds(Vector2Int pos)
		{
			return pos.X <= (_width - 1) && pos.X >= 0 && pos.Y >= 0 && pos.Y <= (_height-1);
		}
	}
}
