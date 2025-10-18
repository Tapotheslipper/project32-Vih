public abstract class Contact
{
    // fields
    public string FullName { get; set; }
    public string PhoneNum { get; set; }

    // constructor
    public Contact(string name, string phone)
    {
        FullName = name;
        PhoneNum = phone;
    }

    // methods
    public abstract string GetDisplay();
}