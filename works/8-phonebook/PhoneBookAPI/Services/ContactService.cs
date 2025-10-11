public class ContactService
{
    // fields
    private readonly Dictionary<string, Contact> _contacts;

    // constructor
    public ContactService()
    {
        _contacts = new Dictionary<string, Contact>
        {
            { "0001", new PersonalContact("placeholder", "0001") },
            { "0002", new BusinessContact("placeholder", "0002") }
        };
    }

    // methods
    public IEnumerable<string> GetAllContacts()
    {
        return _contacts.Values.Select(c => c.GetDisplay());
    }

    public void AddContact(Contact c)
    {
        if (!_contacts.ContainsKey(c.PhoneNum))
        {
            _contacts.Add(c.PhoneNum, c);
        }
    }

    public Contact GetContactById(int id)
    {
        var key = _contacts.Keys.ElementAtOrDefault(id);
        if (!string.IsNullOrEmpty(key)) {
            return _contacts[key];
        }
        return null;
    }

    public void DeleteContact(int id)
    {
        var key = _contacts.Keys.ElementAtOrDefault(id);
        if (!string.IsNullOrEmpty(key))
        {
            _contacts.Remove(key);
        }
    }
}