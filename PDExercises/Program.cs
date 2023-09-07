while (true)
{
    SelectAssignment();
    
}

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
        case "5": Assignment5();
            break;
        case "6": Assignment6();
            break;
        case "7": Assignment7();
            break;
        case "8": Assignment8();
            break;
        case "9": Assignment9();
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
    Console.WriteLine("Write a value you wish to divide");
    int value = int.Parse(Console.ReadLine());
    Console.WriteLine("Write a value for the divisor");
    int divisor = int.Parse(Console.ReadLine());

    float result = (float)value / (float)divisor;
    Console.WriteLine($"{value} / {divisor} = {result}");
}

void Assignment3()
{
    Console.WriteLine("Write a value you wish to divide");
    int value = int.Parse(Console.ReadLine());
    Console.WriteLine("Write a value for the divisor");
    int divisor = int.Parse(Console.ReadLine());

    float result = (float)value % (float)divisor;
    Console.WriteLine($"The Remainder of {value} / {divisor} is {result}");
}

void Assignment4()
{
    Console.WriteLine("Write a value for the radius of a circle");
    float radius = float.Parse(Console.ReadLine());
    float area = MathF.PI * MathF.Pow(radius, 2);
    Console.WriteLine($"The Area of the circle is {area}");
}

void Assignment5()
{
    Console.WriteLine("Write a value for the radius of a circle");
    int value = int.Parse(Console.ReadLine());
    int negatedValue = -value;
    Console.WriteLine($"The Area of the circle is {negatedValue}");
}
void Assignment6()
{
   
}
void Assignment7()
{
    
}
void Assignment8()
{
   
}
void Assignment9()
{
    
}