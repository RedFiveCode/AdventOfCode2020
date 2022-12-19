#pragma once
#include "ShuttleData.h"
#include <map>


class ShuttleDataCalculator
{
public:
	ShuttleDataCalculator(const ShuttleData& shuttleData) : m_data(shuttleData)
	{ }

	int Calculate();

private:
	ShuttleData m_data;

	std::map<int, std::pair<int, int>> CalculateMap(const int start, const int finish) const;

};

