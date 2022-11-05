// See https://aka.ms/new-console-template for more information

using ColonyInTheConsole;
using System.Runtime.InteropServices;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int consoleWidth = Game.ConsoleWidth + 4;
int consoleHeight = Game.ConsoleHeight;


if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
	Console.SetWindowSize(consoleWidth, consoleHeight);
}

Game.Start();


