using System;
using System.Collections.Generic;

public class Logic
{
	public static List<Card> CreateDeck(List<Card> deck)
	{
		List<string> value = new List<string> 
		{
			"A",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10",
			"J",
			"Q",
			"K"
		};

		List<string> face = new List<string>
		{
			"Clubs",
			"Spades",
			"Diamonds",
			"Hearts"
		};

		for (var i = 0; i < value.Count; i++)
		{
			for (var j = 0; j < face.Count; j++)
			{
				Card card = new Card(value[i], face[j]); 
				deck.Add(card);
			}
		}
		return deck;
	}

	public static List<Card> DealHand(List<Card> deck)
	{
		List<Card> hand = new List<Card>();

		for (var i = 0; i < 2; i++)
		{
			Card card = new Card();
			Random rnd = new Random();
			int index = rnd.Next(deck.Count);
			card = deck[index];
			hand.Add(card);
			deck.RemoveAt(index);
		}
		return hand;
	}

	public static List<Card> DealOneCard(List<Card> deck, List<Card> hand)
	{
		for (var i = 0; i < 1; i++)
		{
			Card card = new Card();
			Random rnd = new Random();
			int index = rnd.Next(deck.Count);
			card = deck[index];
			deck.RemoveAt(index);
			hand.Add(card);
		}
		return hand;
	}

	public static int CurrentCardTotal(List<Card> hand)
	{
		string numberString;
		int number = 0;

		foreach (var item in hand)
		{
			numberString = item.Value.Substring(0, 1);

			if (numberString == "A")
			{
				number += 1;
			}
			else if (numberString == "1" || numberString == "J" || numberString == "Q" ||numberString == "K")
			{
				number += 10;
			}
			else
			{
				number += Convert.ToInt32(numberString);
			}
		}
		return number;
	}

	public static List<Card> DealerHitsOrStays(List<Card> deck, List<Card> hand, int totalScore)
	{
		if (totalScore < 16)
		{
			hand = DealOneCard(deck, hand);
		}

		return hand;
	}

	public static bool PlayerWon(int playerScore, int dealerScore)
	{
		bool won = false;

		if (playerScore < 21 && playerScore > dealerScore || dealerScore > 21 && playerScore < 21)
		{
			won = true;
			return won;
		}
		else
		{
			return won;
		}
	}

}