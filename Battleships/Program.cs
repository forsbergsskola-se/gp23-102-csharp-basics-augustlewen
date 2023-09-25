const int rows = 10;
const int columns = 10;
int[] shipSizes = new int[5] {5, 4, 3, 3, 2};
    
Grid[] playerGrid = new Grid[2];
Ship[] p1Ships = new Ship[shipSizes.Length];
Ship[] p2Ships = new Ship[shipSizes.Length];
ConsoleColor[] playerColor = new ConsoleColor[2] { ConsoleColor.Yellow , ConsoleColor.Blue};
bool gameOver = false;

for (int p = 0; p < 2; p++)
{
    playerGrid[p] = new Grid(rows, columns);
    playerGrid[p].position = new GridPosition[rows, columns];
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < columns; c++)
        {
            playerGrid[p].position[r, c] = new GridPosition(" ");
        }
    }
}


for (int s = 0; s < shipSizes.Length; s++)
{
    p1Ships[s] = new Ship(shipSizes[s]);
    p2Ships[s] = new Ship(shipSizes[s]);
}


Console.ForegroundColor = playerColor[0];
Console.WriteLine("Player 1, place your ships");
foreach (Ship ship in p1Ships)
    PlaceShip(ship, 0, 1);

Console.Clear();

Console.ForegroundColor = playerColor[1];
Console.WriteLine("Player 2, place your ships");
foreach (Ship ship in p2Ships)
    PlaceShip(ship, 1, 0);

Console.Clear();


while (gameOver == false)
{
    GameTurn(0, 1);
    if (gameOver)
        break;
    GameTurn(1, 0);
}


void GameTurn(int player, int enemyPlayer)
{
    Console.ForegroundColor = playerColor[player];

    DrawGameBoard(enemyPlayer, player, false);
    Console.WriteLine($"Where do you want to shoot Player{player + 1}?");
    InputPosFunction:
    InputPosition(out int column, out int row);

    GridPosition gridPosition = playerGrid[enemyPlayer].position[row, column];
    if (gridPosition.boardSymbol != " ")
    {
        Console.WriteLine("Invalid Position, You have already shot here");
        goto InputPosFunction;
    }

    string feedbackMessage = "";

    if (gridPosition.ship == null)
    {
        gridPosition.boardSymbol = "o";
        feedbackMessage = "Miss";
        // Console.WriteLine("Miss");
    }
    else
    {
        feedbackMessage = "Hit!";

        // Console.WriteLine("Hit!");
        gridPosition.boardSymbol = "X";
        gridPosition.ship.hp--;
    }
    
    DrawGameBoard(enemyPlayer, player, false);
    Console.WriteLine("");
    Console.WriteLine(feedbackMessage);

    if(gridPosition.ship is { hp: 0 })
    {
        gridPosition.ship.sunk = true;
        Console.WriteLine("Sunk!!");

        if (IsAllEnemyShipSunk(enemyPlayer))
        {
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("");

            Console.WriteLine($"Player{player + 1} Wins!!!");
            gameOver = true;
        }
    }

    System.Threading.Thread.Sleep(1500);
    Console.WriteLine("");
}

bool IsAllEnemyShipSunk(int enemyPlayer)
{
    foreach (Ship ship in GetPlayerShips(enemyPlayer))
    {
        if (!ship.sunk)
            return false;
    }

    return true;
}

Ship[] GetPlayerShips(int player)
{
    if (player == 0)
        return p1Ships;

    return p2Ships;
}

void PlaceShip(Ship ship, int player, int otherPlayer)
{
    PlaceShip:
    DrawGameBoard(player, otherPlayer, true);
    Console.WriteLine($"Where do you want to place your {ship.size}x ship?");
    InputPosition(out int column, out int row);

    if (!IsViablePlacement(ship, true, playerGrid[player], row, column) &&
        !IsViablePlacement(ship, false, playerGrid[player], row, column))
    {
        Console.WriteLine("Invalid Placement, must be placed 2 units away from other ships and inside the grid");
        goto PlaceShip;
    }

    Horizontal:
    Console.WriteLine("Horizontal (y/n)?");
    string inputHorizontal = Console.ReadLine();
    if (inputHorizontal != "y" && inputHorizontal != "n")
    {
        Console.WriteLine("Invalid input, only 'y'(yes) or 'n'(no) are valid inputs");
        goto Horizontal;
    }

    bool isHorizontal = inputHorizontal == "y";
    if (!IsViablePlacement(ship, isHorizontal, playerGrid[player], row, column))
    {
        Console.WriteLine("Invalid Placement, must be placed 2 units away from other ships and inside the grid");
        goto PlaceShip;
    }

    for (int i = 0; i < ship.size; i++)
    {
        playerGrid[player].position[row, column].ship = ship;

        if (inputHorizontal == "y")
            column++;
        else
            row++;
    }
}

bool IsViablePlacement(Ship ship, bool isHorizontal, Grid playerGrid, int row, int collumn)
{
    for (int i = 0; i < ship.size; i++)
    {
        // if (playerGrid.position[row, collumn].ship != null)
        //     return false;
        if (row >= rows || collumn >= columns)
            return false;

        for (int r = -1; r < 2; r++)
        {
            if(r == -1 || r == 1)
                if(row + r < 0 || row + r >= rows)
                    continue;
                
            for (int c = -1; c < 2; c++)
            {
                if(c == -1 || c == 1)
                    if(collumn + c < 0 || collumn + c >= columns)
                        continue;

                if (playerGrid.position[row + r, collumn + c].ship != null && playerGrid.position[row + r, collumn + c].ship != ship)
                    return false;
            }
        }


        if (isHorizontal)
            collumn++;
        else
            row++;
    }

    return true;
}



void InputPosition(out int inputColumn, out int inputRow)
{
    InputPos:
    string placementPosition = Console.ReadLine();

    if (placementPosition.Length != 2)
    {
        Console.WriteLine("Invalid Position, positions are written with a letter(column) and a number(row). Ex: 'a0'");
        goto InputPos;
    }

    inputColumn = char.ToUpper(placementPosition[0]) - 65; //Change Letter To a value based on it's alphabetical position
    inputRow = char.ToUpper(placementPosition[1]) - 48; //Change string value to it's int value

    if (!IsViableGridPosition(placementPosition, inputColumn, inputRow))
    {
        Console.WriteLine(
            "Invalid Position, positions are written with a letter(column) and a number(row). Ex: 'a0'");
        goto InputPos;
    }
}

bool IsViableGridPosition(string inputString, int inputColumn, int inputRow)
{
    if (inputColumn < 0 || inputColumn > columns)
        return false;
    if (inputRow < 0 || inputRow > rows)
        return false;

    return true;
}


void DrawGameBoard(int player, int otherPlayer, bool placementPhase)
{
    string collumnLine = " | ";
    for(int c = 0; c < columns; c++)
        collumnLine += (char)(c + 65) + " | ";
    Console.WriteLine(collumnLine.ToLower());

    for (int row = 0; row < rows; row++)
    {
        // string rowString = row + "| ";
        Console.Write(row + "| ");


        for (int collumn = 0; collumn < columns; collumn++)
        {
            if (placementPhase)
            {

                if (playerGrid[player].position[row, collumn].ship != null)
                {
                    Console.Write("X");
                    // rowString += "X";
                }
                else
                    Console.Write(" ");

                    // rowString += " ";
                
                // rowString += " | ";
                Console.Write(" | ");


            }
            else
            {
                string symbol = playerGrid[player].position[row, collumn].boardSymbol;
                
                if(symbol == "X")
                    WriteInColor(symbol, playerColor[player], playerColor[otherPlayer]);
                else if (symbol == "o")
                    WriteInColor(playerGrid[player].position[row, collumn].boardSymbol, ConsoleColor.Red,
                        playerColor[otherPlayer]);
                else
                    Console.Write(" ");
                
                Console.Write(" | ");

                // rowString += playerGrid[player].position[row, collumn].boardSymbol;
            }

        }
        Console.WriteLine();

    }
}

static void WriteInColor(string message, ConsoleColor messageColor, ConsoleColor color)
{
    Console.ForegroundColor = messageColor;
    Console.Write(message);
    Console.ForegroundColor = color;

}

public class Grid
{
    public GridPosition[,] position;

    public Grid(int rows, int collumns)
    {
        position = new GridPosition[rows, collumns];
    }
}

public class GridPosition
{
    public Ship ship;
    public string boardSymbol;

    public GridPosition(string boardSymbol)
    {
        // this.ship = ship;
        this.boardSymbol = boardSymbol;
    }
}

public class Ship
{
    public int size;

    // public int[] position;
    public int hp;
    public bool sunk = false;

    public Ship(int size)
    {
        this.size = size;
        this.hp = size;
    }
}