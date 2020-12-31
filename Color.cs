using System;

public class Color
{

	public static void Dealer(string card)
	{
		Console.ForegroundColor = ConsoleColor.DarkRed;
		Console.WriteLine(card);
		Console.ResetColor();
	}

	public static void Player(string card)
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(card);
		Console.ResetColor();
	}

		public static void Choices(string card)
	{
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine(card);
		Console.ResetColor();
	}
}