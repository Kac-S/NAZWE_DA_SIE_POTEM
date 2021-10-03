import numpy as np
import random

def canPlant(map, x,y):
    if map[x][y] > 0:
        return False
    elif map[x-1][y] == 1 or map[x-1][y] == 3:
        return False
    elif map[x+1][y] == 1 or map[x+1][y] == 3:
        return False
    elif map[x-1][y-1] == 1 or map[x-1][y-1] == 3:
        return False
    elif map[x+1][y-1] == 1 or map[x+1][y-1] == 3:
        return False
    elif map[x-1][y+1] == 1 or map[x-1][y+1] == 3:
        return False
    elif map[x+1][y+1] == 1 or map[x+1][y+1] == 3:
        return False
    else:
        return True

def generatePlant(n, map):

    for i in range(0,n):
        w = len(map[0])
        h = len(map)

        x = random.randrange(1,w-1,1)
        y = random.randrange(1,h-1,1)

        while not canPlant(map, x, y):
            x = random.randrange(1, w-1, 1)
            y = random.randrange(1, h-1, 1)

        map[x][y] = 2;
    return map