namespace ColonyInTheConsole
{
	public class Window
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Window(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public void DisplayWindow()
		{
			Console.WriteLine("Displaying Window");
		}
	}

		
}
