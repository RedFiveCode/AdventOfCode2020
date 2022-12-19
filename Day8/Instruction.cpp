#include <sstream>
#include "Instruction.h"

std::string Instruction::ToString() const
{
	std::stringstream ss;

	ss << "{" << m_instruction << " " << std::showpos << m_argument << std::noshowpos << "} ";

	return ss.str();

}

