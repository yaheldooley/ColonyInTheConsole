using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public static class Utils
	{
		public static string SurroundStringWithBox(this string s)
		{
			string ulCorner = "╔";
			string llCorner = "╚";
			string urCorner = "╗";
			string lrCorner = "╝";
			string vertical = "║";
			string horizontal = "═";

			string[] lines = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);


			int longest = 0;
			foreach (string line in lines)
			{
				if (line.Length > longest)
					longest = line.Length;
			}
			int width = longest + 2; // 1 space on each side


			string h = string.Empty;
			for (int i = 0; i < width; i++)
				h += horizontal;

			// box top
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(ulCorner + h + urCorner);

			// box contents
			foreach (string line in lines)
			{
				double dblSpaces = (((double)width - (double)line.Length) / (double)2);
				int iSpaces = Convert.ToInt32(dblSpaces);

				if (dblSpaces > iSpaces) // not an even amount of chars
				{
					iSpaces += 1; // round up to next whole number
				}

				string beginSpacing = "";
				string endSpacing = "";
				for (int i = 0; i < iSpaces; i++)
				{
					beginSpacing += " ";

					if (!(iSpaces > dblSpaces && i == iSpaces - 1)) // if there is an extra space somewhere, it should be in the beginning
					{
						endSpacing += " ";
					}
				}
				// add the text line to the box
				sb.AppendLine(vertical + beginSpacing + line + endSpacing + vertical);
			}

			// box bottom
			sb.AppendLine(llCorner + h + lrCorner);

			// the finished box
			return sb.ToString();
		}

		public static void AddBorderToCharArray(char[,] array)
		{
			char ulCorner = '╔';
			char llCorner = '╚';
			char urCorner = '╗';
			char lrCorner = '╝';
			char vertical = '║';
			char horizontal = '═';

			int width = array.GetLength(0);
			int height = array.GetLength(1);

			if (width < 2 || height < 2) return;

			array[0, 0] = ulCorner;
			array[width - 1, 0] = urCorner;
			array[0, height - 1] = llCorner;
			array[width - 1, height - 1] = lrCorner;

			if (width > 2)
			{
				for (int x = 1; x < width - 1; x++)
				{
					array[x, 0] = horizontal;
					array[x, height -1] = horizontal;
				}
			}

			if (height > 2)
			{
				for (int y = 1; y < height -1; y++)
				{
					array[0, y] = vertical;
					array[width - 1, y] = vertical;
				}
			}
			
		}

		public static char[,] FillCharArray(int width, int height)
		{
			char[,] chars = new char[width, height];

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					chars[j, i] = ' ';
				}
			}
			return chars;
		}

		public static char[,] CenterTextAtTopOfArray(char[,] chars, string text)
		{
			int xWidth = chars.GetLength(0);
			int leftPos = (xWidth / 2) - (text.Length / 2);
			for (int i = 0; i < xWidth; i++)
			{
				if(i >= leftPos && i < leftPos + text.Length)
				{
					int pos = i - leftPos;
					chars[i, 0] = text[pos];
				}
			}
			return chars;
		}

		public static char[,] StringTo2DCharArray(string s, char[] splitters)
		{
			string[] lineArray = s.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

			int arrWidth = LargestLengthInStringArray(lineArray);
			int arrHeight = lineArray.Length;

			char[,] charArray = new char[arrWidth, arrHeight];
			
			for (int i = 0; i < arrHeight; i++)
			{
				char[] lineChars = lineArray[i].ToCharArray();


				for (int j = 0; j < arrWidth; j++)
				{
					if (j < lineChars.Length) charArray[j, i] = lineChars[j];
					else charArray[j, i] = ' ';
				}
			}
			return charArray;
		}

		public static void JustifyContentTo2DCharArray(char[,] arrayToUpdate, char[,] arrayToAdd, Align alignment)
		{
			int startX = 0;
			int startY = 0;

			switch (alignment)
			{
				case Align.MiddleLeft:
					startX = 0;
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.MiddleCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.MiddleRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.TopLeft:
					startX = 0;
					startY = 0;
					break;

				case Align.TopCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = 0;
					break;

				case Align.TopRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = 0;
					break;

				case Align.BottomLeft:
					startX = 0;
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

				case Align.BottomCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

				case Align.BottomRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

			}
			int endX = Math.Clamp(startX + arrayToAdd.GetLength(0), 0, arrayToUpdate.GetLength(0));
			int endY = Math.Clamp(startY + arrayToAdd.GetLength(1), 0, arrayToUpdate.GetLength(1));

			for (int y = startY; y  < endY; y++)
			{
				for (int x = startX; x < endX; x++)
				{
					int xIndex = x - startX;
					int yIndex = y - startY;
					arrayToUpdate[x, y] = arrayToAdd[xIndex, yIndex];
				}

			}
		}

		public static void JustifyContentTo2DCharArray(char[,] arrayToUpdate, string s, Align alignment)
		{
			int startX = 0;
			int startY = 0;

			char[,] arrayToAdd = StringTo2DCharArray(s, new char[] { '\n', '\r'});

			switch (alignment)
			{
				case Align.MiddleLeft:
					startX = 0;
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.MiddleCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.MiddleRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.TopLeft:
					startX = 0;
					startY = 0;
					break;

				case Align.TopCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = 0;
					break;

				case Align.TopRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = 0;
					break;

				case Align.BottomLeft:
					startX = 0;
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

				case Align.BottomCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

				case Align.BottomRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

			}
			int endX = Math.Clamp(startX + arrayToAdd.GetLength(0), 0, arrayToUpdate.GetLength(0));
			int endY = Math.Clamp(startY + arrayToAdd.GetLength(1), 0, arrayToUpdate.GetLength(1));

			for (int y = startY; y < endY; y++)
			{
				for (int x = startX; x < endX; x++)
				{
					int xIndex = x - startX;
					int yIndex = y - startY;
					arrayToUpdate[x, y] = arrayToAdd[xIndex, yIndex];
				}

			}
		}

		public static void JustifyContentTo3DCharArray(char[,,] arrayToUpdate, char[,] arrayToAdd, int zLevel,Align alignment)
		{
			if (zLevel < 0 || zLevel > arrayToUpdate.GetLength(zLevel))
			{
				Console.WriteLine($"!! 3D array does not have a z value of {zLevel} !!");
				return;
			}

			int startX = 0;
			int startY = 0;

			switch (alignment)
			{
				case Align.MiddleLeft:
					startX = 0;
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.MiddleCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.MiddleRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = (arrayToUpdate.GetLength(1) / 2) - (arrayToAdd.GetLength(1) / 2);
					break;

				case Align.TopLeft:
					startX = 0;
					startY = 0;
					break;

				case Align.TopCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = 0;
					break;

				case Align.TopRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = 0;
					break;

				case Align.BottomLeft:
					startX = 0;
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

				case Align.BottomCenter:
					startX = (arrayToUpdate.GetLength(0) / 2) - (arrayToAdd.GetLength(0) / 2);
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

				case Align.BottomRight:
					startX = arrayToUpdate.GetLength(0) - arrayToAdd.GetLength(0);
					startY = arrayToUpdate.GetLength(1) - arrayToAdd.GetLength(1);
					break;

			}
			int endX = Math.Clamp(startX + arrayToAdd.GetLength(0), 0, arrayToUpdate.GetLength(0));
			int endY = Math.Clamp(startY + arrayToAdd.GetLength(1), 0, arrayToUpdate.GetLength(1));

			for (int y = startY; y < endY; y++)
			{
				for (int x = startX; x < endX; x++)
				{
					int xIndex = x - startX;
					int yIndex = y - startY;
					arrayToUpdate[x, y, zLevel] = arrayToAdd[xIndex, yIndex];
				}

			}
		}

		public static int LargestLengthInStringArray(string[] sArray)
		{
			int largestSoFar = 0;
			foreach (string s in sArray)
			{
				if (s.Length > largestSoFar) largestSoFar = s.Length;
			}
			return largestSoFar;
		}

		public static string Visualize2dArrayAsString(char[,] array)
		{
			string displayedString = string.Empty;
			int width = array.GetLength(0);
			int height = array.GetLength(1);

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					displayedString += array[j, i];
					if (j == width - 1)
					{
						displayedString += "\n";
					}
				}
			}
			return displayedString;
		}
		
	}
}
