#pragma once
#include "Deck.h"
#include <vector>

class Round
{
public:
	Round(const Deck& deckOne, const Deck& deckTwo)
	{
		m_deckOne = deckOne;
		m_deckTwo = deckTwo;
	}

	bool IsSame() const
	{
		return m_deckOne == m_deckTwo;
	}

private:
	Deck m_deckOne;
	Deck m_deckTwo;

};

class GameHistory
{
public:
	bool IsPreviousRoundWithSameCardsInSameOrder(const Deck& deckOne, const Deck& deckTwo) const
	{
		//auto match = std::any_of(m_rounds.begin(), m_rounds.end(), [deckOne, deckTwo](const Round& r){
		//	return r.IsSame();
		//	});
		//return match;

		auto matchOne = std::any_of(m_roundsPlayerOne.begin(), m_roundsPlayerOne.end(), [deckOne](const Deck& d) {
			return d == deckOne;
		});

		auto matchTwo = std::any_of(m_roundsPlayerTwo.begin(), m_roundsPlayerTwo.end(), [deckTwo](const Deck& d) {
			return d == deckTwo;
			});

		return matchOne && matchTwo;
	}

private:
	std::vector<Round> m_rounds;

	std::vector<Deck> m_roundsPlayerOne;
	std::vector<Deck> m_roundsPlayerTwo;
};



