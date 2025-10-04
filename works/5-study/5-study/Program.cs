interface IWorker
{
    void Work();
}

abstract class Employee : IWorker
{
    public string name { get; set; }
    public Employee(string name) => this.name = name;
    public abstract void Work();
}

class Developer : Employee
{
    public Developer(string name) : base(name) { }
    public override void Work()
    {
        Console.WriteLine($"{this.name} пишет код и сосёт нахуй.");
    }
}