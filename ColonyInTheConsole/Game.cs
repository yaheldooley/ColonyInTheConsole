using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public static class Game
	{
		
		public static int WindowWidth = 100;
		public static int ConsoleHeight = 40;
		public static Dictionary<string, Window> AllWindows = new Dictionary<string, Window>();
		public static Window activeWindow;
		public static List<ConsoleKey> PressedKeys => _pressedKeys;
		private static List<ConsoleKey> _pressedKeys = new List<ConsoleKey>();

		public static TimeSpan deltaTime;
		public static void Start()
		{
			Console.CursorVisible = false;

			var gameWindow = new GameWindow("ColonyInTheConsole", WindowWidth, ConsoleHeight - 20);
			var menuWindow = new MenuWindow("MENU", WindowWidth, 4);

			Scene scene = new Scene(100, 100);
			Person p = new Person("John Thomas", 34, 'X');
			scene.AddEntity(p);

			activeWindow = gameWindow;
			var startTime = DateTime.Now;

			// Game Loop
			while (true)
			{
				// Get keyboard inputs
				var oldKeysPressed = new List<ConsoleKey>(PressedKeys);
				PressedKeys.Clear();

				while (Console.KeyAvailable)
				{
					PressedKeys.Add(Console.ReadKey(intercept: false).Key);
				}
				foreach (var key in PressedKeys)
				{
					if (!oldKeysPressed.Contains(key))
					{
						//KeyPressed Event
						activeWindow.KeyPressed(key);
					}
				}

				foreach (var key in oldKeysPressed)
				{
					if (!PressedKeys.Contains(key))
					{
						//KeyReleased Event
						activeWindow.KeyReleased(key);
					}
				}
				string change = activeWindow.GetChanges();
				if (change != string.Empty)
				{
					InputParser.ParseInput(change);
					//Do stuff like:
					//Change Window
					//Assign Character
				}

				var now = DateTime.Now;
				deltaTime = now - startTime;
				startTime = now;

				scene.Update();

				activeWindow.DisplayWindow();
			}

		}

	}
}
