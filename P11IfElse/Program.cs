Console.WriteLine("What's your age");
int age = int.Parse(Console.ReadLine());

string ageGroup;

if (age <= 12)
    ageGroup = "Child";
else if (age <= 19)
    ageGroup = "Teenager";
else
    ageGroup = "Grownup";

Console.WriteLine("You are a " + ageGroup);

Console.WriteLine("Give me another integer");
int value = int.Parse(Console.ReadLine());

int largerValue = age > value ? age : value;

Console.WriteLine("The maximum is: " + largerValue);
Console.WriteLine(largerValue % 2 == 0 ? "Your number is an even number" : "Your number is an odd number");
