namespace ColonyInTheConsole
{
	public class MainMenu : View
	{
		public MainMenu(string name, int width, int height) : base(name, width, height)
		{
			canvasState = Viewing.MainMenu;
			base.AddWindowToGame();
			SetViewStatus();
		}
		public override void DisplayWindowStatusContents()
		{
			if (!Dirty) return;
			Dirty = false;
			Game.Screen.FillDisplayWithViewContent(ViewStatus, Align.MiddleCenter);
		}

		private void SetViewStatus()
		{
			string artString =		"~         ~~          __\r\n" +
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

			ViewStatus = Utils.StringTo2DCharArray(artString, new char[] { '\n', '\r' });
		}

		private string GetHotKeyString()
		{
			string hotkeyString = "";
			hotkeyString += $"\n[N] NEW GAME\n\n[C] CONTINUE\n\n[O] OPTIONS ";
			return hotkeyString;
		}

		public override void KeyPressed(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.N:
					Game.ChangeCamera(Viewing.GamePlay);
					//Utils.JustifyContentTo2DCharArray(Game.activeWindow.CameraStatus, Utils.StringTo2DCharArray(Scene.DefaultScene(),new char[] {'\n' }), Align.TopCenter);
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
