Console.WriteLine("Give me a number of seconds");
string input = Console.ReadLine();

float floatValue = float.Parse(input);

float total = floatValue / (60 * 60 * 24);

int seconds = (int)(floatValue % 60);
int minutes =(int)((floatValue / 60) % 60);
int hours = (int)((floatValue / (60 * 60)) % 24);
int days = (int)(total);


Console.WriteLine("Seconds:" + seconds);
Console.WriteLine("Minutes:" + minutes);
Console.WriteLine("Hours:" + hours);
Console.WriteLine("Days:" + days);

Console.WriteLine($"{days} : {hours} : {minutes} : {seconds}");
Console.WriteLine("In total, that's " + total);