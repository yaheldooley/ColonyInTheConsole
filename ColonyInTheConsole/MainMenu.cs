namespace ColonyInTheConsole
{
	public class MainMenu : Window
	{
		public MainMenu(string name, int width, int height) : base(name, width, height)
		{
			canvasState = CanvasState.MainMenu;
			base.AddWindowToGame();
		}

		public override string DisplayWindowStatusContents()
		{
			if (!Dirty) return string.Empty;
			Dirty = false;
			string villageString =	"~         ~~          __\r\n" +
									"       _T      .,,.    ~--~ ^^\r\n" +
									" ^^   // \\                    ~\r\n" +
									"      ][O]    ^^      ,-~ ~\r\n" +
									"   /''-I_I         _II____\r\n" +
									"__/_  /   \\ ______/ ''   /'\\_,__\r\n" +
									"  | II--'''' \\,--:--..,_/,.-{ },\r\n" +
									"; '/__\\,.--';|   |[] .-.| O{ _ }\r\n" +
									":' |  | []  -|   ''--:.;[,.'\\,/\r\n" +
									"'  |[]|,.--'' '',   ''-,.    |\r\n" +
									"  ..    ..-''    ;       ''. '";

			Utils.JustifyContentTo2DCharArray( WindowStatus, Utils.StringTo2DCharArray( villageString, new char[] { '\n', '\r'}), Align.MiddleCenter );

			string displayedString = base.DisplayWindowStatusContents();
			displayedString += GetHotKeyString();
			Console.WriteLine( Utils.DrawInConsoleBox(displayedString) );
			return displayedString;
		}

		private string GetHotKeyString()
		{
			string hotkeyString = "";
			hotkeyString += $"[N] NEW GAME\n\n[C] CONTINUE\n\n[O] OPTIONS ";
			return hotkeyString;
		}

		public override void KeyPressed(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.N:
					Game.activeScene = new Scene(Game.ConsoleWidth, Game.ConsoleHeight);
					Game.ChangeWindow(CanvasState.GamePlay);
					Utils.JustifyContentTo2DCharArray(Game.activeWindow.WindowStatus, Utils.StringTo2DCharArray(Scene.DefaultScene(),new char[] {'\n' }), Align.TopCenter);
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
