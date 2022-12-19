#pragma once
#include <vector>
#include <map>
#include "Instruction.h"

class Program
{
public:
	Program() : m_accumulator(0), m_instructionPointer(0) {}

	bool Run(const std::vector<Instruction>& instructions);

private:
	void ExecuteInstruction(const Instruction& instruction);
	void ShowState() const;
	void ShowState(const Instruction& instruction) const;

	void UpdateHistory(const int address);
	bool CheckHistory(const int address) const;

	int m_accumulator;
	int m_instructionPointer;
	std::vector<int> m_executionHistory;
};

