public class PersonalContact : Contact
{
    // constructor
    public PersonalContact(string name, string phone) : base(name, phone) { }

    // methods
    public override string GetDisplay()
    {
        return $"Личный контакт: {FullName} - {PhoneNum}";
    }
}