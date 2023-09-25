Console.WriteLine("Please pass me a seed (integer).");
int seed = int.Parse(Console.ReadLine());

Random random = new Random(seed);

OutputRandomValues(0, 5, 3, true);
OutputRandomValues(0.0, 0.5, 3, false);
OutputRandomValues(0.2, 0.7, 3, false);

void OutputRandomValues(double min, double max, int amount, bool isInteger)
{
    Console.WriteLine($"Three numbers between {min} and {max}:");

    for(int i = 0; i < amount; i++)
    {
        if(isInteger)
            Console.WriteLine(random.Next((int)min, (int)max));
        else
            Console.WriteLine(random.NextDouble() * (max - min) + min);
    }
}

Console.WriteLine("Give me a crit chance between 0.0 (0%) and 1.0 (100%)");
float critChance = float.Parse(Console.ReadLine());

for(int i = 0; i < 5; i++)
{
    Console.WriteLine(random.NextDouble() < critChance ? "Crit" : "No Crit");


}

