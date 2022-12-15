namespace TaskManager;

public class Project
{
    private double _InitialCost;
    private int _Key;
    private string _Title;
    private Customer _customer;
    public List<Task> tasks;

    public double InitialCost
    {
        get => _InitialCost;
        set => _InitialCost = value;
    }

    public int Key
    {
        get => _Key;
        set => _Key = value;
    }

    public string Title
    {
        get => _Title;
        set => _Title = value;
    }

    public Customer Customer
    {
        get => _customer;
        set => _customer = value;
    }

    public Project(string title, int key, Customer customer)
    {
        Title = title;
        Key = key;
        Customer = customer;
    }

    public override string ToString()
    {
        return $"Проект {Title}: Бюджет проекта - {InitialCost}, Ключ - {Key},\n" +
               $"Клиент - {Customer}";
    }

    
    
    
    
    
    
}