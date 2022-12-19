#pragma once
#include <queue>

class Deck
{
public:
	int Draw()
	{
		int tip = m_deck.front();

		m_deck.pop();

		return tip;
	}

	void LoadCards(const std::vector<int>& cards)
	{
		for (int card : cards)
		{
			m_deck.push(card);
		}
	}

	void Add(int card1, int card2)
	{
		m_deck.push(card1);
		m_deck.push(card2);
	}

	bool IsEmpty() const
	{
		return m_deck.empty();
	}

	int GetScore()
	{
		int total = 0;

		while (!m_deck.empty())
		{
			auto size = m_deck.size();
			auto current = m_deck.front();

			total += (current * size);

			m_deck.pop();
		}

		return total;
	}

	int Size() const
	{
		return m_deck.size();
	}

	bool operator == (const Deck& rhs) const
	{
		return m_deck == rhs.m_deck;
	}

private:
	std::queue<int> m_deck;


};

