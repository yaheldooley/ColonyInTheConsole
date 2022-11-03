using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public static class InputParser
	{
		public static void ParseInput(string input)
		{
			switch (input)
			{
				case "MENU":
					Game.activeWindow = Game.AllWindows["MENU"];
					Game.activeWindow.Dirty = true;
					break;

				case "ColonyInTheConsole":
					Game.activeWindow = Game.AllWindows["ColonyInTheConsole"];
					Game.activeWindow.Dirty = true;
					break;

			}
				
		}
	}
}
