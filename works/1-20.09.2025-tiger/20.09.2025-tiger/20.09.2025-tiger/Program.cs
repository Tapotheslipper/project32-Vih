Console.Write("Name your tiger: ");
string newTigerName = Console.ReadLine();

Tiger tig1 = new Tiger(newTigerName);
Console.WriteLine($"You have a tiger named {tig1.Name}. His energy is {tig1.Energy} by default and can be {tig1.MaxEnergy} at max.");

while (tig1.Energy >= 0)
{
    Console.WriteLine($"Your tiger's energy now: {tig1.Energy}");
    Console.Write("Tell your tiger to roar (1), hunt (2) or rest (3) by typing the digit in. First two actions will consume its energy and third will restore some (typing '4' in will close the program'): ");

    int actionIndex = Convert.ToInt16(Console.ReadLine());
    switch (actionIndex)
    {
        case 1:
            tig1.ToAct(tig1.ToRoar, tig1.RoarCost);
            break;
        case 2:
            tig1.ToAct(tig1.ToHunt, tig1.HuntCost);
            break;
        case 3:
            tig1.ToRest();
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Enter a proper digit.");
            break;
    }
}

public class Tiger
{
    public string Name { get; private set; }
    public int Energy { get; private set; } = 100;
    public int MaxEnergy { get; private set; } = 150;
    public int RoarCost { get; private set; } = 15;
    public int HuntCost { get; private set; } = 18;
    public int RestAdd { get; private set; } = 30;

    public Tiger(string name)
    {
        Name = name;
    }

    public void ToAct(Action action, int cost)
    {
        if (Energy >= cost)
        {
            action();
            Energy -= cost;
        }
        else
        {
            ToStop();
        }
    }

    public void ToStop()
    {
        Console.WriteLine("The tiger's energy is not enough to perform that action.");
    }
    public void ToRoar()
    {
        Console.WriteLine("The tiger roars!");
    }
    public void ToHunt()
    {
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
}
