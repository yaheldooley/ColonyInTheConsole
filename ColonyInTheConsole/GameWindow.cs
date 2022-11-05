using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public class GameWindow : Window
	{
		public GameWindow(string name, int width, int height) : base(name, width, height)
		{
			canvasState = CanvasState.GamePlay;
			base.AddWindowToGame();
		}

		public override string DisplayWindowStatusContents()
		{
			if (!Dirty) return string.Empty;
			Dirty = false;
			string displayedString = base.DisplayWindowStatusContents();
			displayedString += GetHotKeyString();
			Console.WriteLine(Utils.DrawInConsoleBox(displayedString));
			return displayedString;
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
	}
}
