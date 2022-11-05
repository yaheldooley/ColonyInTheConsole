using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ColonyInTheConsole
{
	public static class Game
	{
		
		public static int ConsoleWidth = 100;
		public static int ConsoleHeight = 40;

		public static Dictionary<CanvasState, Window> AllWindows = new Dictionary<CanvasState, Window>();
		public static Window activeWindow = new MainMenu("Colony In The Console - Main Menu", ConsoleWidth, ConsoleHeight - 20);
		public static List<ConsoleKey> PressedKeys => _pressedKeys;
		private static List<ConsoleKey> _pressedKeys = new List<ConsoleKey>();

		public static TimeSpan deltaTime;

		public static Scene activeScene;

		public static void Start()
		{
			Console.CursorVisible = false;

			var gameWindow = new GameWindow("Colony In The Console", ConsoleWidth, ConsoleHeight - 20);
			var pauseMenu = new PauseMenu("Pause Menu", ConsoleWidth, 4);

			//Scene scene = new Scene(100, 100);
			//Person p = new Person("John Thomas", 34, 'X');
			//scene.AddEntity(p);

			var startTime = DateTime.Now;

			// Game Loop
			while (true)
			{
				HandleUserInput();

				//Update Delta Time
				var now = DateTime.Now;
				deltaTime = now - startTime;
				startTime = now;

				activeWindow.Update();

				//Do stuff like:
				//Change Window
				//Assign Character

				activeWindow.DisplayWindowStatusContents();
			}

		}

		private static void HandleUserInput()
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
		}

		public static void ChangeWindow(CanvasState state)
		{
			if (state != CanvasState.None && state != activeWindow.canvasState)
			{
				
			}
		}

	}
}
