using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public class PauseMenu : View
	{
		public PauseMenu(string name, int width, int height) : base(name, width, height)
		{
			canvasState = Viewing.PauseMenu;
			base.AddWindowToGame();
			ViewStatus = Utils.StringTo2DCharArray(GetHotKeyString(), new char[] { '\n', '\r' });
		}

		public override void DisplayWindowStatusContents()
		{
			if (!Dirty) return;
			Dirty = false;

			Game.Screen.FillDisplayWithViewContent(ViewStatus, Align.TopCenter);
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

		public override void OnEnable()
		{
			
		}

		public override void OnDisable()
		{
			
		}
	}
}
