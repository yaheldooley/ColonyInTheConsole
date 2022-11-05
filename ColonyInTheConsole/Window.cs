﻿using System.Text;
using System.Xml.Linq;

namespace ColonyInTheConsole
{
	public abstract class Window
	{
		public string Name = "";
		public int Width = 0;
		public int Height = 0;
		public CanvasState canvasState;

		public bool Dirty { get; set; }

		public char[,] WindowStatus;

		public Window(string name, int width, int height)
		{
			Name = name;
			Width = width;
			Height = height;

			WindowStatus = Utils.FillCharArray(width, height);
			WindowStatus = Utils.CenterTextAtTopOfArray(WindowStatus, Name);
			Dirty = true;
		}

		public virtual void AddWindowToGame()
		{
			Game.AllWindows.Add(canvasState, this);
		}

		public abstract void Update();

		public virtual string DisplayWindowStatusContents()
		{
			Console.Clear();
			string displayedString = string.Empty;
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					displayedString += WindowStatus[j, i];
					if (j == Width - 1)
					{
						displayedString += "\n";
					}
				}
			}
			return displayedString;
		}		

		public virtual void KeyPressed(ConsoleKey key)
		{

		}
		public virtual void KeyReleased(ConsoleKey key)
		{

		}

		public void SetPositionInWindow(int X, int Y, char c)
		{
			if (X < 0 || X > Width -1 || Y < 0 || Y > Height -1)
			{
				Console.WriteLine($"Character couldn't be set at {X},{Y} because it is out of the windows bounds.");
				return;
			}
			if (WindowStatus[X, Y] == c) return;
			WindowStatus[X, Y] = c;
			Dirty = true;
		}
	}

}
