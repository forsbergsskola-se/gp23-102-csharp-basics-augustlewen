SelectAssignment();

void SelectAssignment()
{
    Console.WriteLine("Input a number between 1-9 to select the assignment");

    switch (Console.ReadLine())
    {
        case "1": Assignment1();
            break;
        case "2": Assignment2();
            break;
        case "3": Assignment3();
            break;
        case "4": Assignment4();
            break;
        case "5": Assignment1();
            break;
        case "6": Assignment1();
            break;
        case "7": Assignment1();
            break;
        case "8": Assignment1();
            break;
        case "9": Assignment1();
            break;
        default: Console.WriteLine("Error, invalid input");
            SelectAssignment();
            break;
    }
    
}

void Assignment1()
{
    Console.WriteLine("Write a value for km/h to convert it to m/s");
    float kmh = float.Parse(Console.ReadLine());
    float ms = kmh * 5 / 18;
    Console.WriteLine($"{kmh}km/h = {ms}m/s");
}

void Assignment2()
{
    Console.WriteLine("Write a value for km/h to convert it to m/s");
    float kmh = float.Parse(Console.ReadLine());
    float ms = kmh * 5 / 18;
    Console.WriteLine($"{kmh}km/h = {ms}m/s");
}

void Assignment3()
{
    Console.WriteLine("Write a value for km/h to convert it to m/s");
    float kmh = float.Parse(Console.ReadLine());
    float ms = kmh * 5 / 18;
    Console.WriteLine($"{kmh}km/h = {ms}m/s");
}

void Assignment4()
{
    Console.WriteLine("Write a value for km/h to convert it to m/s");
    float kmh = float.Parse(Console.ReadLine());
    float ms = kmh * 5 / 18;
    Console.WriteLine($"{kmh}km/h = {ms}m/s");
}