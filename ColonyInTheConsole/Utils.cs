using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public static class Utils
	{
		public static string DrawInConsoleBox(this string s)
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
	}
}
