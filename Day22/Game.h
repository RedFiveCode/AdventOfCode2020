#pragma once
#include <vector>
#include <iostream>
#include "Deck.h"
#include "GameHistory.h"

class Game
{
public:
	void StartPlayerOne(const std::vector<int>& cards)
	{
		m_deckOne.LoadCards(cards);
	}

	void StartPlayerTwo(const std::vector<int>& cards)
	{
		m_deckTwo.LoadCards(cards);
	}

	void PlayPart1()
	{
		while (!m_deckOne.IsEmpty() && !m_deckTwo.IsEmpty())
		{
			PlayRound();
		}

		std::cout << "Game over after " << m_rounds << " round(s)\n";
		if (m_deckOne.IsEmpty())
		{
			std::cout << "Player Two wins, score " << m_deckTwo.GetScore() << "\n";
		}
		else
		{
			std::cout << "Player One wins, score " << m_deckOne.GetScore() << "\n";
		}
	}

	void PlayPart2()
	{
		GameHistory history;

		if (history.)
	}

	void PlayRound()
	{
		m_rounds++;

		auto playerOne = m_deckOne.Draw();
		auto playerTwo = m_deckTwo.Draw();

		std::cout << "Round " << m_rounds << " : Player One " << playerOne << ", Player Two " << playerTwo;

		if (playerOne > playerTwo)
		{
			// player one wins this round
			std::cout << "; Player One wins\n";

			m_deckOne.Add(playerOne, playerTwo);
		}
		else
		{
			// player two wins this round
			std::cout << "; Player Two wins\n";

			m_deckTwo.Add(playerTwo, playerOne);
		}
	}

	bool IsNewGameRequired(int cardOne, int cardTwo)
	{
		// If both players have at least as many cards remaining in their deck as the value of the card they just drew,
		// the winner of the round is determined by playing a new game of Recursive Combat

		return (m_deckOne.Size() > cardOne && m_deckTwo.Size() >= cardTwo);
	}


private:
	Deck m_deckOne;
	Deck m_deckTwo;
	int m_rounds{ 0 };

};

