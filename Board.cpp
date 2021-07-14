#include "Board.h"

Board::Board()
{
    boardGrid = new char*[3];
    for(int i = 0; i < 3; i++)
        boardGrid[i] = new char[3];
}

Board::~Board()
{
    for(int i = 0; i < 3; i++)
    {
        delete[] boardGrid[i];
    }
    delete[] boardGrid;
}

void Board::clearboard()
{
    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
            boardGrid[i][j]=' ';
    }
}

void Board::displayboard()
{
    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
            std::cout << "[" << boardGrid[i][j] << "]";
        
        std::cout << "\t\t";
        for(int j = 0; j < 3; j++)
            std::cout << "[" << refGrid[i][j] << "]";
        
        std::cout << std::endl;
    }
}
