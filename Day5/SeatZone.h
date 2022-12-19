#pragma once
#include <vector>
#include <string>
#include <utility>

struct Seat
{
	int Row;
	int Column;
	int Id;
	std::string Key;

	Seat(int r, int c, int id, const std::string& k)
	{
		Row = r;
		Column = c;
		Id = id;
		Key = k;
	}
};



class SeatZone
{
public:
	std::string GetRowText(const std::string& rowText) const
	{
		return rowText.substr(0, 7);
	}

	std::string GetColumnText(const std::string& rowText) const
	{
		return rowText.substr(7, 3);
	}

	int GetRow(const std::string& rowText) const
	{
		if (rowText.size() != 7)
		{
			return -1;
		}

		return GetRowColumn(rowText, std::make_pair(0, 127));
	}

	int GetColumn(const std::string& columnText) const
	{
		if (columnText.size() != 3)
		{
			return -1;
		}
		return GetRowColumn(columnText, std::make_pair(0, 7));
	}

	int GetRowColumn(const std::string& columnText, const std::pair<int, int>& seed) const
	{
		auto result = seed;

		for (int n = 0; n < (int)columnText.size(); n++)
		{
			auto current = columnText[n];

			if (current == 'L' || current == 'F')
			{
				result = LowerHalf(result);
			}
			else if (current == 'R' || current == 'B')
			{
				result = UpperHalf(result);
			}
		}

		return result.first; // first should equal second
	}

	int GetSeatId(const int row, const int column) const
	{
		return (row * 8) + column;
	}

	std::pair<int, int> LowerHalf(const std::pair<int, int>& value) const
	{
		int half = (value.second - value.first + 1) / 2;

		return std::make_pair(value.first, value.first + half - 1);
	}

	std::pair<int, int> UpperHalf(const std::pair<int, int>& value) const
	{
		int half = (value.second - value.first + 1) / 2;

		return std::make_pair(value.first + half, value.second);
	}
};

