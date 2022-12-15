using System.Xml.Schema;

namespace TaskManager;

public class Customer
{
    private string _ContactEmail;
    private string _ContactPerson;
    private string _ContactPhone;
    private string _Name;

    public string ContactEmail => _ContactEmail;

    public string ContactPerson => _ContactPerson;

    public string ContactPhone => _ContactPhone;

    public string Name => _Name;

    public Customer(string email, string person, string phone, string name)
    {
        _ContactEmail = email;
        _ContactPerson = person;
        _ContactPerson = person;
        _Name = name;
    }

    public override string ToString()
    {
        return $"Клиент {ContactPerson}, eMail Address - {ContactEmail}," +
               $" Phone Number - {ContactPhone}, Name - {Name}";
    }
}