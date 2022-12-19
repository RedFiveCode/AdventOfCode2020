// Day5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <algorithm>
#include "SeatZone.h"
#include "BoardingPassData.h"

int main()
{
    std::cout << "Hello World!\n";

    SeatZone zones;

    auto result = zones.LowerHalf(std::make_pair(0, 127));
    std::cout << result.first << ", " << result.second << std::endl;

    auto result2 = zones.UpperHalf(std::make_pair(0, 63));
    std::cout << result2.first << ", " << result2.second << std::endl;


    //std::vector<std::string> seats = {
    //    "FBFBBFFRLR",
    //    "FFFBBBFRRR",
    //    "BBFFBBFRLL"
    //};

    BoardingPassData data;
    auto seats = data.Data;
    
    int maxId = -1;
    std::vector<Seat> seatList;

    for (auto& seat : seats)
    {
        auto rowText = zones.GetRowText(seat);
        auto columnText = zones.GetColumnText(seat);

        auto row = zones.GetRow(rowText);
        auto column = zones.GetColumn(columnText);
        auto id = zones.GetSeatId(row, column);

        maxId = std::max(maxId, id);

        seatList.push_back(Seat(row, column, id, seat));

        std::cout << seat << " : row " << row << ", column " << column << ", id " << id << std::endl;
    }

    std::cout << "MaxId " << maxId << std::endl;

    std::sort(seatList.begin(), seatList.end(), [](const Seat& x, const Seat& y)
    { return x.Id < y.Id; }
    );


    std::cout << "Part 2" << std::endl;
    for (int i = 0; i < (int)seatList.size() - 1; i++)
    {
        auto& first = seatList[i];
        auto& second = seatList[i + 1];

        if (first.Id + 1 != second.Id)
        {
            std::cout << "Mismatch at index " << i << " : Id " << first.Id << std::endl;
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
