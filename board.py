import numpy as np
class Board:
    states = ['win1','win2','tie','still_playing']
    def __init__(self):
        self.grid = -1 * np.ones(shape=(3,3),dtype=int)
        self.turn = 1
        self.state = states[3]
        self.p1 = 'x'
        self.p2 = 'o'
        
    def showboard(self):
        print(self.grid)

    def isposvalid(self,pos):
        if self.grid[pos] != -1:
            return False
        else:
            return True
    
    def mark(self,pos):
        if self.isposvalid(pos) and self.state = states[3]:
            if self.turn % 2 != 0:
                self.grid[pos] = 1
            else:
                self.grid[pos] = 2
            self.turn += 1

b1 = Board()
b1.showboard()
