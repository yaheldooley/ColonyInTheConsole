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
		}

		public override string DisplayWindow()
		{
			if (!Dirty) return string.Empty;
			Dirty = false;
			string displayedString = base.DisplayWindow();
			displayedString += GetHotKeyString();
			Console.WriteLine(Utils.DrawInConsoleBox(displayedString));
			return displayedString;
		}

		private string GetHotKeyString()
		{
			string hotkeyString = "\nHOTKEYS\n";
			hotkeyString += $" [1] PERSON, [2] ASSIGN, [M] MENU";
			return hotkeyString;
		}
		
		public override void KeyPressed(ConsoleKey key)
		{
			//Console.WriteLine($"{key} pressed!");
			switch (key)
			{
				case ConsoleKey.M:
					changedString = "MENU";
					break;

				default:
					Dirty = true;
					break;
			}
				
		}
		public override void KeyReleased(ConsoleKey key)
		{
			
		}

	}
}
