#pragma once
#include <string>
#include <vector>
#include "ShuttleData.h"

class ShuttleDataReader
{
public:
	ShuttleData Read(const std::string& filename) const;

private:
	std::vector<std::string> ReadFile(const std::string& filename) const;
	ShuttleData ParseLines(const std::vector<std::string>& lines) const;
};
