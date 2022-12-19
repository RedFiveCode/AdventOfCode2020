#pragma once
#include <vector>
#include "Instruction.h"

class ProgramReader
{
public:
	std::vector<Instruction> ReadInstructions(const std::string& filename);

private:
	std::vector<std::string> ReadFile(const std::string& filename);
	Instruction ParseLine(const std::string& line);
};

