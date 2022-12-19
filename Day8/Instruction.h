#pragma once
#include <string>

class Instruction
{
public:
	Instruction(const std::string& instruction) : m_instruction(instruction), m_argument(0) {}
	Instruction(const std::string& instruction, int argument) : m_instruction(instruction), m_argument(argument) {}

	std::string OpCode() const { return m_instruction; }
	int Argument() const { return m_argument; }
	std::string ToString() const;

private:
	std::string m_instruction;
	int m_argument;
};

