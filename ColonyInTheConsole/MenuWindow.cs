using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public class PauseMenu : Window
	{
		public PauseMenu(string name, int width, int height) : base(name, width, height)
		{
			canvasState = CanvasState.PauseMenu;
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
			string hotkeyString = "";
			hotkeyString += $" [B] BACK TO GAME\n\n[Q] QUIT";
			return hotkeyString;
		}

		public override void KeyPressed(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.B:

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
