public class BusinessContact : Contact
{
    // constructor
    public BusinessContact(string name, string phone) : base(name, phone) { }

    // methods
    public override string GetDisplay()
    {
        return $"Бизнес контакт: {FullName} - {PhoneNum}";
    }
}