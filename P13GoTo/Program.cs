Random random = new Random();

int number = random.Next(1, 101);
    
Console.WriteLine("I have picked a number (1-100). It's your turn to guess it!");

AskForNumber:
int input = int.Parse(Console.ReadLine());

if (input != number)
{
    if(input < number)
        Console.WriteLine("Nope! My number is Greater!");
    else
        Console.WriteLine("Nope! My number is Smaller!");

    goto AskForNumber;
}

Console.WriteLine("That's the number! Well played!");