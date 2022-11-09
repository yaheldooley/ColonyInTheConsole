using System.Text;
using System.Xml.Linq;

namespace ColonyInTheConsole
{
	public abstract class View
	{
		public string Name = "";
		public int Width = 0;
		public int Height = 0;
		public Viewing canvasState;

		public bool Dirty { get; set; }

		public char[,] ViewStatus;

		public View(string name, int width, int height)
		{
			Name = name;
			Width = Math.Clamp(width, 0, Game.ConsoleWidth - Game.Screen.BorderWidth);
			Height = Math.Clamp(height, 0, Game.ConsoleHeight - Game.Screen.BorderWidth);

			ViewStatus = Utils.FillCharArray(width, height);
			Dirty = true;
		}

		public virtual void AddWindowToGame()
		{
			Game.AllViews.Add(canvasState, this);
		}

		public abstract void Update();
		public abstract void DisplayWindowStatusContents();

		public abstract void OnEnable();
		public abstract void OnDisable();

		public virtual void KeyPressed(ConsoleKey key)
		{

		}
		public virtual void KeyReleased(ConsoleKey key)
		{

		}

		public void SetPositionInWindow(int X, int Y, char c)
		{
			if (X < 0 || X > Width -1 || Y < 0 || Y > Height -1)
			{
				Console.WriteLine($"Character couldn't be set at {X},{Y} because it is out of the windows bounds.");
				return;
			}
			if (ViewStatus[X, Y] == c) return;
			ViewStatus[X, Y] = c;
			Dirty = true;
		}
	}

}
