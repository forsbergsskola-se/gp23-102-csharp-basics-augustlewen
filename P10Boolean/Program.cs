Console.WriteLine("What is your age");
int age = int.Parse(Console.ReadLine());

bool isChild = age >= 0 && age <= 12;
bool isTeenager = age > 12 && age <= 19;
bool isGrownup = age > 19;


Console.WriteLine("You are a Child: " + isChild);
Console.WriteLine("You are a Teenager: " + isTeenager);
Console.WriteLine("You are a Grownup: " + isGrownup);