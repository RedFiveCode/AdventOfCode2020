#include <iostream>
#include "Patcher.h"


std::vector<int> Patcher::GetNoOpAndJumpIndices(const std::vector<Instruction>& instructions)
{
	std::vector<int> results;

	for (size_t i = 0; i < instructions.size(); i++)
	{
		const auto& current = instructions[i];
		if (current.OpCode() == "jmp" || current.OpCode() == "nop")
		{
			results.push_back(i);
		}
	}

	return results;
}

void Patcher::Patch(std::vector<Instruction>& instructions, int index, const Instruction& newInstruction)
{
	const auto original = instructions[index];

	std::cout << "Patching address " << index << " : " << original.ToString() << " -> " << newInstruction.ToString();

	instructions[index] = newInstruction;
}