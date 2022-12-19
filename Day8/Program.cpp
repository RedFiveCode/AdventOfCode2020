#include "Program.h"
#include <iostream>

bool Program::Run(const std::vector<Instruction>& instructions)
{
	m_accumulator = 0;
	m_instructionPointer = 0;
	m_executionHistory.clear();

	bool finished = false;

	while (!finished)
	{
		auto currentInstruction = instructions[m_instructionPointer];

		// check for infinite looping
		if (CheckHistory(m_instructionPointer))
		{
			std::cout << "Infinite loop detected!" << std::endl;
			ShowState(currentInstruction);

			return false;
		}

		//ShowState(currentInstruction);
		ExecuteInstruction(currentInstruction);
		//ShowState();

		finished = ((size_t)m_instructionPointer >= instructions.size());
	}

	ShowState();
	return finished;
}

void Program::ExecuteInstruction(const Instruction& instruction)
{
	//if (instruction.OpCode() == "nop" && instruction.Argument() == -462)
	//{
	//	std::cout << " breakpoint!";
	//}

	if (instruction.OpCode() == "nop")
	{
		UpdateHistory(m_instructionPointer); // update map of instructions that have been run
		m_instructionPointer++;
	}
	else if (instruction.OpCode() == "acc")
	{
		UpdateHistory(m_instructionPointer); // update map of instructions that have been run

		m_accumulator += instruction.Argument();
		m_instructionPointer++;
	}
	else if (instruction.OpCode() == "jmp")
	{
		UpdateHistory(m_instructionPointer); // update map of instructions that have been run

		m_instructionPointer += instruction.Argument();
	}
	else
	{
		std::cout << instruction.OpCode() << " is unexpected" << std::endl;
	}
}

void Program::ShowState() const
{
	std::cout << "ip: " << m_instructionPointer << ", acc: " << m_accumulator << std::endl;
}

void Program::ShowState(const Instruction& instruction) const
{
	auto alreadyRunInstruction = CheckHistory(m_instructionPointer) ? " *" : "";

	std::cout << "ip: " << m_instructionPointer << ", acc: " << std::showpos << m_accumulator << std::noshowpos << alreadyRunInstruction << " " << instruction.ToString();
}

void Program::UpdateHistory(const int address)
{
	// update map of instructions that have been run
	m_executionHistory.push_back(address);
}

bool Program::CheckHistory(const int address) const
{
	return std::find(m_executionHistory.begin(), m_executionHistory.end(), address) != m_executionHistory.end();
}
