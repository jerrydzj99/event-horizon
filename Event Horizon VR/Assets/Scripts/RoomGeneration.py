import random

#the dimensions of the maze
xwide, yhigh = 5, 5
room  = '.'
empty = '#'

field = []
for y in range(yhigh):
    row = []
    for x in range(xwide):
        row.append('?')
    field.append(row)

frontier = []

def carve(y, x):
    extra = []
    field[y][x] = room
    if x > 0:
        if field[y][x-1] == '?':
            field[y][x-1] = ','
            extra.append((y,x-1))
    if x < xwide - 1:
        if field[y][x+1] == '?':
            field[y][x+1] = ','
            extra.append((y,x+1))
    if y > 0:
        if field[y-1][x] == '?':
            field[y-1][x] = ','
            extra.append((y-1,x))
    if y < yhigh - 1:
        if field[y+1][x] == '?':
            field[y+1][x] = ','
            extra.append((y+1,x))

    random.shuffle(extra)
    frontier.extend(extra)

def harden(y, x):
    field[y][x] = empty

def check(y, x):
    edgestate = 0
    if x > 0:
        if field[y][x-1] == room:
            edgestate += 1
    if x < xwide-1:
        if field[y][x+1] == room:
            edgestate += 10
    if y > 0:
        if field[y-1][x] == room:
            edgestate += 100
    if y < yhigh-1:
        if field[y+1][x] == room:
            edgestate += 1000

    if  [1,10,100,1000].count(edgestate):
        return True
    return False
    

start_x = random.randint(0, xwide-1)
start_y = random.randint(0, yhigh-1)
final_x, final_y = 0, 0

carve(start_y,start_x)

size = 0

while(len(frontier)):
    print(frontier)
    choice = frontier[len(frontier)-1]
    if check(*choice):
        carve(*choice)
    else:
        harden(*choice)
    frontier.remove(choice)
    if len(frontier) >= size:
        final_y, final_x = frontier[len(frontier)-1]
        size = len(frontier)

# all "holes" become non-rooms
for y in range(yhigh):
    for x in range(xwide):
        if field[y][x] == '?':
            field[y][x] = empty

field[start_y][start_x] = 'S'
field[final_y][final_x] = 'G'

#print matrix function for testing
def print_m(nrow, ncol, matrix):
    for y in range(nrow):
        row = ''
        for x in range(ncol):
            row += field[y][x]
        print(row)

print_m(xwide, yhigh, field)

    