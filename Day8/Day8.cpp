// Day8.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "ProgramReader.h"
#include "Program.h"
#include "Patcher.h"

int main()
{
    ProgramReader reader;
    //auto instructions = reader.ReadInstructions("C:\\JM\\Stuff\\Advent of Code 2020\\Day8\\TestData.txt");
    //auto instructions = reader.ReadInstructions("C:\\JM\\Stuff\\Advent of Code 2020\\Day8\\Data.txt");

    auto instructions = reader.ReadInstructions("C:\\JM\\Stuff\\Advent of Code 2020\\Day8\\Data.txt");


    // Part one 
    Program program;
    //program.Run(instructions); // acc is 1501

    // Part two
    Patcher patcher;
    auto instructionIndices = patcher.GetNoOpAndJumpIndices(instructions);

    for (int i : instructionIndices)
    {
        std::cout << "Patch " << i << " of " << instructionIndices.size() << std::endl;

        // patch a copy of the instructions and run it
        // need to detect for loops
        auto patchedInstructions = std::vector<Instruction>(instructions);

        auto originalInstruction = patchedInstructions[i];

        auto newOpCode = (originalInstruction.OpCode() == "nop" ? "jmp" : "nop");
        Instruction newInstruction(newOpCode, originalInstruction.Argument());

        patcher.Patch(patchedInstructions, i, newInstruction);

        auto result = program.Run(patchedInstructions);

        if (result) // run was successful; infinite loop NOT detected
        {
            // acc is 509
            break;
        }
    }
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
