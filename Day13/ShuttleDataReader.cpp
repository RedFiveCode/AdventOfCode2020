#include <fstream>
#include <stdexcept>
#include <string>
#include <sstream>
#include <vector>
#include <iterator>
#include "ShuttleDataReader.h"

void eraseAllSubStr(std::string& mainStr, const std::string& toErase)
{
	size_t pos = std::string::npos;
	// Search for the substring in string in a loop untill nothing is found
	while ((pos = mainStr.find(toErase)) != std::string::npos)
	{
		// If found then erase it from string
		mainStr.erase(pos, toErase.length());
	}
}

// https://stackoverflow.com/questions/236129/how-do-i-iterate-over-the-words-of-a-string
template <typename Out>
void split(const std::string& s, char delim, Out result) {
	std::istringstream iss(s);
	std::string item;
	while (std::getline(iss, item, delim)) {
		*result++ = item;
	}
}

std::vector<std::string> split(const std::string& s, char delim) {
	std::vector<std::string> elems;
	split(s, delim, std::back_inserter(elems));
	return elems;
}


ShuttleData ShuttleDataReader::Read(const std::string& filename) const
{
	auto lines = ReadFile(filename);

	return ParseLines(lines);
}

std::vector<std::string> ShuttleDataReader::ReadFile(const std::string& filename) const
{
	// https://stackoverflow.com/questions/2602013/read-whole-ascii-file-into-c-stdstring
	std::ifstream s(filename);

	std::vector<std::string> lines;
	std::string line;

	// Read the next line from File until it reaches the end
	while (std::getline(s, line))
	{
		if (line.size() > 0)
		{
			lines.push_back(line);
		}
	}

	s.close();

	return lines;
}

ShuttleData ShuttleDataReader::ParseLines(const std::vector<std::string>& lines) const
{
	if (lines.size() != 2)
	{
		throw std::runtime_error("Insufficient lines");
	}

	int timestamp = std::atoi(lines[0].c_str());

	std::vector<std::string> ids = split(lines[1], ',');

	std::vector<int> offsets;

	for (auto& s : ids)
	{
		if (s != "x")
		{
			offsets.push_back(std::stoi(s));
		}
	}

	return ShuttleData(timestamp, offsets);
}
