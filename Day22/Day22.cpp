// Day22.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "Game.h"

int main()
{
    std::cout << "Hello World!\n";

    Game game;
    // test data
    //game.StartPlayerOne({9,2,6,3,1});
    //game.StartPlayerTwo({5,8,4,7,10});

    game.StartPlayerOne({ 10,
39,
16,
32,
5,
46,
47,
45,
48,
26,
36,
27,
24,
37,
49,
25,
30,
13,
23,
1,
9,
3,
31,
14,
4 });

    game.StartPlayerTwo({ 2,
15,
29,
41,
11,
21,
8,
44,
38,
19,
12,
20,
40,
17,
22,
35,
34,
42,
50,
6,
33,
7,
18,
28,
43});

    game.PlayPart1();
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
