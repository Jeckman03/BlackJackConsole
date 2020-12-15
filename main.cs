using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {

		// Fields
		List<Card> Cards = new List<Card>();
		List<Card> playerHand = new List<Card>();
		List<Card> dealerHand = new List<Card>();

		int dealerScore;
		int playerScore;
		int playerChoice = 1;

		// Creating a new deck of cards
		Cards = Logic.CreateDeck(Cards);

		// Dealing two cards to the dealer and player
		playerHand = Logic.DealHand(Cards);
		dealerHand = Logic.DealHand(Cards);

		do
		{

			// Displaying the hands and the total value of the cards
			dealerScore = DealersHand(dealerHand);
			Console.WriteLine($"Total: { dealerScore }");
			playerScore = PlayersHand(playerHand);
			Console.WriteLine($"Total: { playerScore }");

			// Displaying the players options
			playerChoice = DisplayPlayerOptions();

			if (playerChoice == 1)
			{
				playerHand = Logic.DealOneCard(Cards, playerHand);
				playerScore = PlayersHand(playerHand);
				Console.WriteLine($"Total: { playerScore }");
			}

		} while (playerChoice == 1);

		do
		{
			dealerHand = Logic.DealerHitsOrStays(Cards, dealerHand, dealerScore);
			dealerScore = DealerHits(dealerHand);
			Console.WriteLine($"Total: { dealerScore }");

			playerScore = PlayersHand(playerHand);
			Console.WriteLine($"Total: { playerScore }");

		} while (dealerScore < 16);

		bool gameResult = Logic.PlayerWon(playerScore, dealerScore);
		
		WhoWon(gameResult);

    Console.ReadLine();
  }

// --- METHODS ---

	private static void WhoWon(bool won)
	{
		if (won == true)
		{
			Console.WriteLine();
			Console.WriteLine("YOU WON!");
		}
		else
		{
			Console.WriteLine();
			Console.WriteLine("YOU HAVE LOST!");	
		}
	}

	private static int DisplayPlayerOptions()
	{
		bool isValid = false;
		string choice;
		int output;

		do{

			Console.WriteLine();
			Console.WriteLine("------------------");
			Console.WriteLine("Type 1 to Hit");
			Console.WriteLine("Type 2 to Stay");
			Console.Write("Choice: ");
			choice = Console.ReadLine();

			bool correctInput = Int32.TryParse(choice, out output);

			if (correctInput == false)
			{
				Console.WriteLine("You have not entered a valid number");
			}
			output = Convert.ToInt32(choice);

			if (output == 1 || output == 2)
			{	
				isValid = true;
			}
			else
			{
				Console.WriteLine("You have entered an invalid selection. Try again...");
				isValid = false;
			}
		} while (isValid == false);

		return output;
	}

	private static int DealersHand(List<Card> hand)
	{
		Console.Clear();
		int cardCount = 1;
		int totalScore;
		Console.WriteLine();
		Console.WriteLine("---DEALERS HAND---");
		foreach (var item in hand)
		{
			if (cardCount == 1)
			{
				Console.WriteLine("Card 1: ?");
				cardCount++;
			}
			else
			{
				Console.WriteLine($"Card { cardCount }: { item.Value } { item.Face }");
			}
		}
		totalScore = Logic.CurrentCardTotal(hand);

		return totalScore;		
	}

	private static int DealerHits(List<Card> hand)
	{
		Console.Clear();
		int cardCount = 1;
		int totalScore;
		Console.WriteLine();
		Console.WriteLine("---DEALERS HAND---");
		foreach (var item in hand)
		{
			if (cardCount == 1)
			{
				Console.WriteLine($"Card { cardCount }: { item.Value } { item.Face }");
				cardCount++;
			}
			else
			{
				Console.WriteLine($"Card { cardCount }: { item.Value } { item.Face }");
			}
		}
		totalScore = Logic.CurrentCardTotal(hand);

		return totalScore;		
	}


	private static int PlayersHand(List<Card> hand)
	{
		int cardCount = 1;
		int totalScore;
		Console.WriteLine();
		Console.WriteLine("---PLAYERS HAND---");
		foreach (var item in hand)
		{
			Console.WriteLine($"Card { cardCount }: { item.Value } { item.Face }");
			cardCount++;
		}		
		totalScore = Logic.CurrentCardTotal(hand);

		return totalScore;
	}

}