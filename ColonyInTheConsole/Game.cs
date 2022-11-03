using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public static class Game
	{
		

		public delegate void KeyPressedEventHandler(ConsoleKey key);
		public delegate void KeyReleasedEventHandler(ConsoleKey key);

		public static event KeyPressedEventHandler KeyPressed;
		public static event KeyPressedEventHandler KeyReleased;

		public static Window Window { get; private set; }

		public static List<ConsoleKey> PressedKeys => _pressedKeys;
		private static List<ConsoleKey> _pressedKeys = new List<ConsoleKey>();

		public static void Start(Scene firstScene)
		{
			Console.CursorVisible = false;

			//KeyWasPressed += KeyPressed;

			var startTime = DateTime.Now;

			// Game Loop
			while(true)
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
						KeyPressed?.Invoke(key); //KeyPressed Event
					}
				}

				foreach (var key in oldKeysPressed)
				{
					if (!PressedKeys.Contains(key))
					{
						KeyReleased?.Invoke(key); //KeyReleased Event
					}
				}

				var now = DateTime.Now;
				var dt = now - startTime;
				startTime = now;
				
			}

		}

		private static void KeyWasPressed(object sender, ConsoleKey a)
		{
			//Console.WriteLine(startTime);
		}


	}
}
