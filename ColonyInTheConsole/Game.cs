using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ColonyInTheConsole
{
	public static class Game
	{
		public static readonly int ConsoleWidth = 100;
		public static readonly int ConsoleHeight = 40;
		

		public static Dictionary<Viewing, View> AllViews = new Dictionary<Viewing, View>();
		public static View ActiveView;

		public static Screen Screen; // Screen space
		public static Scene ActiveScene; // World Space

		public static List<ConsoleKey> PressedKeys => _pressedKeys;
		private static List<ConsoleKey> _pressedKeys = new List<ConsoleKey>();

		public static TimeSpan deltaTime;

		public static void Start()
		{
			Console.CursorVisible = false;

			Screen = new Screen(ConsoleWidth, ConsoleHeight -10, 4);
			ActiveScene = new Scene(ConsoleWidth, ConsoleHeight, 3, true);

			var mainMenu =	new MainMenu("Colony In The Console", ConsoleWidth - Screen.BorderWidth, ConsoleHeight - 20);
			var gameplay =	new GameWindow("Game", ConsoleWidth - Screen.BorderWidth, ConsoleHeight - 20);
			var pauseMenu = new PauseMenu("Pause Menu", ConsoleWidth - Screen.BorderWidth, 4);

			ActiveView = gameplay;
			ChangeCamera(Viewing.MainMenu);

			Person p = new Person("John Thomas", 34, '8', new int[15,15,0]);
			ActiveScene.AddEntity(p);

			var startTime = DateTime.Now;

			// Game Loop
			while (true)
			{
				HandleUserInput();

				//Update Delta Time
				var now = DateTime.Now;
				deltaTime = now - startTime;
				startTime = now;

				ActiveView.Update();

				UpdateCanvas();
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
					ActiveView.KeyPressed(key);
				}
			}

			foreach (var key in oldKeysPressed)
			{
				if (!PressedKeys.Contains(key))
				{
					//KeyReleased Event
					ActiveView.KeyReleased(key);
				}
			}
		}

		public static void ChangeCamera(Viewing state)
		{
			if (state != Viewing.None && state != ActiveView.canvasState)
			{
				if (AllViews.ContainsKey(state))
				{
					ActiveView.OnDisable();
					ActiveView = AllViews[state];
					ActiveView.OnEnable();
					ActiveView.Dirty = true;
				}
				else Console.WriteLine($"No window for {state} exists");
			}
		}

		public static void UpdateCanvas()
		{
			if (ActiveView == null || ActiveScene == null) return;
			if (!ActiveView.Dirty) return;
			
			//Utils.JustifyContentTo2DCharArray(Canvas, activeWindow.DisplayWindowStatusContents(), Align.TopLeft);
			Screen.Refresh();
		}


	}

}
