using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public class GameWindow : View
	{
		public GameWindow(string name, int width, int height) : base(name, width, height)
		{
			canvasState = Viewing.GamePlay;
			base.AddWindowToGame();
		}

		public override void DisplayWindowStatusContents()
		{
			if (!Dirty) return;
			Dirty = false;
			
			Game.Screen.FillDisplayWithViewContent(VisualizeMapArrayAs2DArray(), Align.TopLeft);

		}

		public static string VisualizeMapArrayAsString()
		{
			string displayedString = string.Empty;
			int width = Game.ActiveScene.Width;
			int height = Game.ActiveScene.Height;

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int[,,] key = new int[j, i, 0];
					if (Game.ActiveScene.EntityLocations.ContainsKey(key))
					{
						displayedString += Game.ActiveScene.EntityLocations[key];
					}
					else displayedString += Game.ActiveScene.Map[j, i, 0];

					if (j == width - 1)
					{
						displayedString += "\n";
					}
				}
			}
			return displayedString;
		}
		public static char[,] VisualizeMapArrayAs2DArray()
		{
			char[,] map2d = new char[Game.Screen.InnerWidth, Game.Screen.InnerHeight];
			int width = Game.Screen.InnerWidth;
			int height = Game.Screen.InnerHeight;

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int[,,] key = new int[j, i, 0];
					if (Game.ActiveScene.EntityLocations.ContainsKey(key))
					{
						map2d[j,i] = Game.ActiveScene.EntityLocations[key];
					}
					else map2d[j,i] = Game.ActiveScene.Map[j, i, 0];
				}
			}
			return map2d;
		}
		private string GetHotKeyString()
		{
			string hotkeyString = " [1] PERSON, [2] ASSIGN, [M] MENU";
			return hotkeyString;
		}
		
		public override void KeyPressed(ConsoleKey key)
		{
			//Console.WriteLine($"{key} pressed!");
			switch (key)
			{
				case ConsoleKey.M:
				
					break;

				default:
					Dirty = true;
					break;
			}
				
		}
		public override void KeyReleased(ConsoleKey key)
		{
			
		}

		public override void Update()
		{
			
		}

		public override void OnEnable()
		{
			Game.ActiveScene.GameWindowVisible = true;
		}

		public override void OnDisable()
		{
			Game.ActiveScene.GameWindowVisible = false;
		}
	}
}
