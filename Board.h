#pragma once
#include <iostream>

class Board
{
public:

    char** boardGrid;
    int refGrid[3][3] = {{7,8,9},{4,5,6},{1,2,3}};

    Board();
    ~Board();
    void clearboard();
    void displayboard();
};