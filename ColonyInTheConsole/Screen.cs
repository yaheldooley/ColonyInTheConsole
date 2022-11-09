using System.Reflection.Metadata.Ecma335;

namespace ColonyInTheConsole
{
	public class Screen
	{
		public char[,] Display { get; private set; }
		public int BorderWidth { get; private set; }
		public int InnerWidth { get; private set; }
		public int InnerHeight { get; private set; }

		private int _width;
		private int _height;
		private int _maxXIndex;
		private int _maxYIndex;

		public Screen(int width, int height, int borderWidth)
		{
			_width = width;
			_height = height;
			BorderWidth = borderWidth;
			_maxXIndex = width - borderWidth;
			_maxYIndex = height - borderWidth;
			InnerWidth = _width - (borderWidth / 2);
			InnerHeight = height - (borderWidth / 2);
			Display = Utils.FillCharArray(_width, _height);
			Utils.AddBorderToCharArray(Display);
		}

		public void Refresh()
		{
			Console.Clear();
			Game.ActiveView.DisplayWindowStatusContents();
			Utils.AddBorderToCharArray(Display);
			Console.WriteLine( Utils.Visualize2dArrayAsString(Display));
		}
		public void FillDisplayWithViewContent(char[,] content, Align align)
		{
			//if (content == String.Empty) return;
			Clear();
			Utils.JustifyContentTo2DCharArray(Display, content, align);

		}


		public void FillDisplayWithViewContent(string content)
		{
			Clear();
			if (content == String.Empty) return;

			var lines = content.Split( new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			if (lines.Length < 1)
			{
				Console.WriteLine($"View {Game.ActiveView.Name} has no content to view");
				return;
			}

			for (int y = 0; y < _maxYIndex; y++)
			{
				if (y >= lines.Length) break;

				var chars = lines[y].ToCharArray();

				for (int x = 0; x < _maxXIndex; x++)
				{
					if (x < chars.Length) Display[BorderWidth + x, BorderWidth + y] = chars[x];
					else break;
				}
			}
		}

		public void Clear()
		{
			for (int y = 0; y < _height; y++)
			{
				for (int x = 0; x < _width; x++)
				{
					Display[x, y] = ' ';
				}
			}
		}

	}

}
