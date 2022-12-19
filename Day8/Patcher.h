#pragma once
#include <vector>
#include "Instruction.h"


class Patcher
{
public:
	std::vector<int> GetNoOpAndJumpIndices(const std::vector<Instruction>& instructions);

	void Patch(std::vector<Instruction>& instructions, int index, const Instruction& newInstruction);

};

