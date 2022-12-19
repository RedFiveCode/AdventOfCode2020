#pragma once
#include <vector>
#include <algorithm>


class ShuttleData
{
public:
	ShuttleData(int timestamp, std::vector<int> busIds) : m_timestamp(timestamp), m_busIds(busIds)
	{ }

	int GetTimestamp() const { return m_timestamp; }
	std::vector<int> GetBusIds() const { return m_busIds; }

	int GetMaxId() const
	{
		auto it = std::max_element(m_busIds.begin(), m_busIds.end());

		return *it;
	}

private:
	int m_timestamp;
	std::vector<int> m_busIds;
};

