Console.Write("Name your tiger: ");
string newTigerName = Console.ReadLine();

Tiger tig1 = new Tiger(newTigerName);
Console.WriteLine($"You have a tiger named {tig1.Name}. His energy is 100 (full) by default.");

while (tig1.Energy >= 0)
{
    Console.WriteLine($"Your tiger's energy now: {tig1.Energy}");
    Console.Write("Tell your tiger to roar (1), hunt (2) or rest (3) by typing in the digit. FIrst two actions will consume its energy and third will restore some (typing in '4' will close the program'): ");

    int actionIndex = Convert.ToInt16(Console.ReadLine());
    if (actionIndex == 1)
    {
        if (tig1.Energy >= tig1.RoarSpend)
        {
            tig1.ToRoar();
        }
        else
        {
            tig1.Stop();
        }
    }
    else if (actionIndex == 2)
    {
        if (tig1.Energy >= tig1.HuntSpend)
        {
            tig1.ToHunt();
        }
        else
        {
            tig1.Stop();
        }
    }
    else if (actionIndex == 3)
    {
        if (tig1.Energy <= tig1.MaxEnergy)
        {
            tig1.ToRest();
        }
    }
    else if (actionIndex == 4)
    {
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Enter a valid digit.");
    }
}

public class Tiger
{
    public string Name { get; set; }
    public int Energy = 100;
    public int MaxEnergy = 150;
    public int RoarSpend = 15;
    public int HuntSpend = 18;
    public int RestAdd = 30;

    public void Stop()
    {
        Console.WriteLine("The tiger's energy is not enough to perform that action.");
    }
    public void ToRoar()
    {
        Energy -= RoarSpend;
        Console.WriteLine("The tiger roars!");
    }
    public void ToHunt()
    {
        Energy -= HuntSpend;
        Console.WriteLine("The tiger hunts...");
    }
    public void ToRest()
    {
        Energy += RestAdd;
        if (Energy > MaxEnergy)
        {
            Energy = MaxEnergy;
        }
        Console.WriteLine("The tiger rests.");
    }

    public Tiger(string name)
    {
        Name = name;
    }
}
