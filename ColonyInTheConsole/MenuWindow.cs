using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public class MenuWindow : Window
	{
		public MenuWindow(string name, int width, int height) : base(name, width, height)
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
			string hotkeyString = "";
			hotkeyString += $" [B] BACK TO GAME\n\n[Q] QUIT";
			return hotkeyString;
		}

		public override void KeyPressed(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.B:
					changedString = "ColonyInTheConsole";
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
