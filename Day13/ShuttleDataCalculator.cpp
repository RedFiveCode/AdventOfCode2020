#include "ShuttleDataCalculator.h"
#include <map>
#include <algorithm>
#include <tuple>



bool IsMultiple(const int value, const int divisor)
{
	return (value % divisor == 0);
}



std::vector<int> GetKeys(const std::map<int, int>& m)
{
	std::vector<int> keys;
	for (auto it = m.begin(); it != m.end(); ++it)
	{
		keys.push_back(it->first);
	}

	return keys;
}

std::vector<int> GetKeys(const std::map<int, std::pair<int, int>>& m)
{
	std::vector<int> keys;
	for (auto it = m.begin(); it != m.end(); ++it)
	{
		keys.push_back(it->first);
	}

	return keys;
}

int ShuttleDataCalculator::Calculate()
{
	int min = m_data.GetTimestamp();
	int maxId = min + m_data.GetMaxId();

	auto map = CalculateMap(min, maxId);

	// get nearest id
	auto times = GetKeys(map);
	//auto it = std::min_element(times.begin(), times.end());

	// The map will be in ascending order according to the values of the key.
	auto it = map.begin();
	auto key = it->first;
	auto value = it->second; // pair

	auto time = value.first;
	auto busId = value.second;
	auto timeDifference = time - min;


	return timeDifference * busId;
}

std::map<int, std::pair<int, int>> ShuttleDataCalculator::CalculateMap(const int start, const int finish) const
{
	std::map<int, std::pair<int, int>> map;

	for (int i = start; i <= finish; i++)
	{
		for (int id : m_data.GetBusIds())
		{
			if (IsMultiple(i, id))
			{
				std::pair<int, int> p(i, id);
				map[i] = p; // ignore multiple matches
			}
		}
	}

	return map;
}