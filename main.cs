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
		bool gameResult = false;
		bool playAgain = false;
		int playerWins = 0;
		int dealerWins = 0;

		MainIntro();

		do
		{
			// Creating a new deck of cards
			Cards = Logic.CreateDeck(Cards);

			// Dealing two cards to the dealer and player
			playerHand = Logic.DealHand(Cards);
			dealerHand = Logic.DealHand(Cards);

			do
			{

				// Displaying the hands and the total value of the cards
				dealerScore = DealersHand(dealerHand);
				Console.WriteLine($"Total: ?");
				playerScore = PlayersHand(playerHand);
				Console.WriteLine($"Total: { playerScore }");

				// Displaying the players options
				playerChoice = DisplayPlayerOptions();

				if (playerChoice == 1)
				{
					playerHand = Logic.DealOneCard(Cards, playerHand);
					playerScore = PlayersHand(playerHand);
					Console.WriteLine($"Total: { playerScore }");
					if (playerScore > 21)
					{
						gameResult = false;
						playerChoice = 2;
						dealerScore = DealersHandRevealed(dealerHand);
						Console.WriteLine($"Total: { dealerScore }");
						playerScore = PlayersHand(playerHand);
						Console.WriteLine($"Total: { playerScore }");
					}

				}
			} while (playerChoice == 1);

			while (dealerScore < 16 && playerScore < 21)
				{
					dealerHand = Logic.DealerHitsOrStays(Cards, dealerHand, dealerScore);
					dealerScore = DealerHits(dealerHand);
					Console.WriteLine($"Total: { dealerScore }");
					playerScore = PlayersHand(playerHand);
					Console.WriteLine($"Total: { playerScore }");
				} 

			if (playerScore < 21 && dealerScore > 15)
			{
				gameResult = false;
				dealerScore = DealersHandRevealed(dealerHand);
				Console.WriteLine($"Total: { dealerScore }");
				playerScore = PlayersHand(playerHand);
				Console.WriteLine($"Total: { playerScore }");
			}

			gameResult = Logic.PlayerWon(playerScore, dealerScore);
		
			WhoWon(gameResult);

			if (gameResult == true)
			{
				playerWins++;
			}
			else
			{
				dealerWins++;
			}

			playAgain = PlayAgain();

		} while (playAgain == true);
		
		EndGameStats(playerWins, dealerWins);


    Console.ReadLine();
  }

// --- METHODS ---

	private static void MainIntro()
	{
		Console.Clear();
		Console.WriteLine();
		Color.Player(@"							WELCOME TO");
		Console.WriteLine();
		Color.Player(@"	
 _____  _____  _   _  _____  _____  _      _____    _____  __  
/  __ \|  _  || \ | |/  ___||  _  || |    |  ___|  / __  \/  | 
| /  \/| | | ||  \| |\ `--. | | | || |    | |__    `' / /'`| | 
| |    | | | || . ` | `--. \| | | || |    |  __|     / /   | | 
| \__/\\ \_/ /| |\  |/\__/ /\ \_/ /| |____| |___   ./ /____| |_
 \____/ \___/ \_| \_/\____/  \___/ \_____/\____/   \_____/\___/
                                                               
                                                               

		");
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("Hit any key to play...");
		Console.ReadLine();
	}

	private static void EndGameStats(int playerWins, int dealerWins)
	{
		Console.Clear();
		Console.WriteLine();
		Console.WriteLine($"You have won { playerWins }, and the dealer won { dealerWins }");
		Console.WriteLine();
		Console.WriteLine("Thanks for playing!");
	}

	private static bool PlayAgain()
	{
		bool output = false;
		Console.Write("Would you like to play again (Y/N): ");
		string playAgain = Console.ReadLine();

		if (playAgain.ToLower() == "y")
		{
			output = true;
			return output;
		}
		else 
		{
			return output;
		}
	}

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
			Color.Choices("Type 1 to Hit");
			Color.Choices("Type 2 to Stay");
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
		Color.Dealer("---DEALERS HAND---");
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

		private static int DealersHandRevealed(List<Card> hand)
	{
		Console.Clear();
		int cardCount = 1;
		int totalScore;
		Console.WriteLine();
		Color.Dealer("---DEALERS HAND---");
		foreach (var item in hand)
		{
			if (cardCount == 1)
			{
				Console.WriteLine($"Card 1: { item.Value } { item.Face }");
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
		Color.Dealer("---DEALERS HAND---");
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
				cardCount++;
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
		Color.Player("---PLAYERS HAND---");
		foreach (var item in hand)
		{
			Console.WriteLine($"Card { cardCount }: { item.Value } { item.Face }");
			cardCount++;
		}		
		totalScore = Logic.CurrentCardTotal(hand);

		return totalScore;
	}

}