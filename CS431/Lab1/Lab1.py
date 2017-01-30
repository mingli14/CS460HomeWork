#!/usr/bin/env python
import numpy as np
import sys

def convertToInt(x):
    """Helper function to be able to use either form
       of the input file: '-' or '-1'
    """
    if x == '-':
        return -1
    else:
        return int(x)

def equalSum(a, b, rows, cols, row, col):
    if (b[row, col] == -1):
        return True
    else:
        if (row == 0 and col == 0):
            if (-1 in b[row : row + 2, col : col +2]):
                return True
            else:
                sum = np.sum(b[row : row + 2, col : col +2]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (row == 0 and 0 < col < cols - 1):
            if (-1 in b[row : row + 2, col - 1 : col +2]):
                return True
            else:
                sum = np.sum(b[row : row + 2, col - 1 : col +2]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (row == 0 and col == cols - 1):
            if (-1 in b[row : row + 2, col - 1 : col + 1]):
                return True
            else:
                sum = np.sum(b[row : row + 2, col - 1 : col + 1]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (0 < row < rows - 1 and col == cols - 1):
            if (-1 in b[row - 1 : row + 2, col - 1 : col + 1]):
                return True
            else:
                sum = np.sum(b[row - 1 : row + 2, col - 1 : col + 1]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (row == rows - 1 and col == cols - 1):
            if (-1 in b[row - 1 : row + 1, col - 1 : col + 1]):
                return True
            else:
                sum = np.sum(b[row - 1 : row + 1, col - 1 : col + 1]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (row == rows - 1 and cols - 1 > col > 0):
            if (-1 in b[row - 1 : row + 1, col - 1 : col + 2]):
                return True
            else:
                sum = np.sum(b[row - 1 : row + 1, col - 1 : col + 2]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (row == rows - 1 and col == 0):
            if (-1 in b[row - 1 : row + 1, col : col + 2]):
                return True
            else:
                sum = np.sum(b[row - 1 : row + 1, col : col + 2]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        elif (0 < row < rows - 1 and col == 0):
            if (-1 in b[row - 1 : row + 2, col : col + 2]):
                return True
            else:
                sum = np.sum(b[row - 1 : row + 2, col : col + 2]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False
        else:
            if (-1 in b[row - 1 : row + 2, col - 1 : col + 2]):
                return True
            else:
                sum = np.sum(b[row - 1 : row + 2, col - 1 : col + 2]) - b[row, col]
                if(sum == a[row, col] or a[row, col] == -1):
                    return True
                return False

def checkBoard(a, b, rows, cols, row, col):
    if (row == 0 and col == 0):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col +1) and equalSum(a, b, rows, cols, row +1, col) and equalSum(a, b, rows, cols, row+1, col+1)):
            return True
        else:
            return False
    elif (row == 0 and 0 < col < cols - 1):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col +1) and equalSum(a, b, rows, cols, row +1, col) and equalSum(a, b, rows, cols, row+1, col+1) and equalSum(a, b, rows, cols, row, col-1) and equalSum(a, b, rows, cols, row+1, col-1)):
            return True
        else:
            return False
    elif (row == 0 and col == cols - 1):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col - 1) and equalSum(a, b, rows, cols, row +1, col) and equalSum(a, b, rows, cols, row+1, col-1)):
            return True
        else:
            return False
    elif (0 < row < rows - 1 and col == cols - 1):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col -1) and equalSum(a, b, rows, cols, row +1, col) and equalSum(a, b, rows, cols, row+1, col-1) and equalSum(a, b, rows, cols, row-1, col-1) and equalSum(a, b, rows, cols, row-1, col)):
            return True
        else:
            return False
    elif (row == rows - 1 and col == cols - 1):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col -1) and equalSum(a, b, rows, cols, row -1, col) and equalSum(a, b, rows, cols, row-1, col-1)):
            return True
        else:
            return False
    elif (row == rows - 1 and cols - 1 > col > 0):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row-1, col) and equalSum(a, b, rows, cols, row, col-1) and equalSum(a, b, rows, cols, row-1, col-1) and equalSum(a, b, rows, cols, row-1, col+1) and equalSum(a, b, rows, cols, row, col+1)):
            return True
        else:
            return False
    elif (row == rows - 1 and col == 0):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col +1) and equalSum(a, b, rows, cols, row -1, col) and equalSum(a, b, rows, cols, row-1, col+1)):
            return True
        else:
            return False
    elif (0 < row < rows - 1 and col == 0):
        if (equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col +1) and equalSum(a, b, rows, cols, row +1, col) and equalSum(a, b, rows, cols, row+1, col+1) and equalSum(a, b, rows, cols, row-1, col) and equalSum(a, b, rows, cols, row-1, col+1)):
            return True
        else:
            return False
    else:
        if (equalSum(a, b, rows, cols, row-1, col-1) and equalSum(a, b, rows, cols, row-1, col) and equalSum(a, b, rows, cols, row-1, col+1) and equalSum(a, b, rows, cols, row, col-1) and equalSum(a, b, rows, cols, row, col) and equalSum(a, b, rows, cols, row, col+1)and equalSum(a, b, rows, cols, row+1, col-1) and equalSum(a, b, rows, cols, row+1, col) and equalSum(a, b, rows, cols, row+1, col+1)):
            return True
        else:
            return False

def setBoard(a, b, nrows, ncols, ur, uc, i, total, c):
    b[ur[i], uc[i]] = 0
    totalCopy = total
    total = total - 1
    if(checkBoard(a, b, nrows, ncols, ur[i], uc[i])):
        if total == 0:
            c[0] = c[0] + 1
            c[1] = c[1] -1
            if c[1] == 1:
                print "Find the first solution for the problem:"
                print "*** 0 means the empty square or the square with data! ***"
                print "*** 1 means the bomb! ***"
                print b
            if c[1] == 0:
                print "Find the second solution for the problem:"
                print "*** 0 means the empty square or the square with data! ***"
                print "*** 1 means the bomb! ***"
                print b
        else:
            setBoard(a, b, nrows, ncols, ur, uc, i + 1, total, c)

    b[ur[i], uc[i]] = 1
    if (checkBoard(a, b, nrows, ncols, ur[i], uc[i])):
        if total == 0:
            c[0] = c[0] + 1
            c[1] = c[1] - 1
            if c[1] == 1:
                print "Find the first solution for the problem:"
                print "*** 0 means the empty square or the square with data! ***"
                print "*** 1 means the bomb! ***"
                print b
            if c[1] == 0:
                print "Find the second solution for the problem:"
                print "*** 0 means the empty square or the square with data! ***"
                print "*** 1 means the bomb! ***"
                print b
        else:
            setBoard(a, b, nrows, ncols, ur, uc, i + 1, total, c)

    b[ur[i], uc[i]] = -1
    total = total + 1



def main(filename):
    """No error checking or handling."""
    with open(filename,'r') as f:
        # first line is # of rows
        nrows = int(f.readline().strip())
        # next line is # of columns
        ncols = int(f.readline().strip())
        # now nrows of the board
        board = np.zeros((nrows,ncols),dtype=int)
        for i in range(nrows):
            board[i,:] = list(map(convertToInt,f.readline().split()))
    print(board)
    c = [0,2]
    boardBoolean = np.copy(board)
    boardBoolean[boardBoolean != -1] = 0
    total = -np.sum(boardBoolean[:,:])
    (ur, uc) = np.where(boardBoolean == -1)
    setBoard(board, boardBoolean, nrows, ncols, ur, uc, 0, total, c)
    if(c[0] ==0):
        print "Can't find the solution for the problem."
    elif(c[0] == 1):
        print "There is only one solution for the problem"
    else:
        print "There are more than one solutions and"
        print "the number of the solutions is " + str(c[0])



if __name__ == "__main__":
    """Expects filename as first argument.  """
    main(sys.argv[1])