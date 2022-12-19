#include "ProgramReader.h"
#include <fstream>
#include <regex>
#include <stdexcept>

std::vector<Instruction> ProgramReader::ReadInstructions(const std::string& filename)
{
	std::vector<Instruction> instructions;

	auto lines = ReadFile(filename);

	for (auto line : lines)
	{
		instructions.push_back(ParseLine(line));
	}

	return instructions;
}

std::vector<std::string> ProgramReader::ReadFile(const std::string& filename)
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

Instruction ProgramReader::ParseLine(const std::string& line)
{
	const auto regex = std::regex("(\\w+) ([+|-]\\d+)");
	std::smatch matches;
	std::regex_match(line, matches, regex);

	if (3 != matches.size())
	{
		throw std::runtime_error("Insufficient matches");
	}

	auto opCode = matches[1];
	auto arg = std::stoi(matches[2]);

	Instruction i(opCode, arg);
	return i;
}



