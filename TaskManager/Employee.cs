namespace TaskManager;

public class Employee
{
    private string _FullName;
    private int _Number;
    private int _Rating;
    private Position _position;
    private int _Hourlyrate;
    

    public string FullName => _FullName;
    public int Number => _Number;
    public int Rating => _Rating;
    public Position Position => _position;
    public int HourlyRate => _Hourlyrate;
    

    public Employee(string fullName, int number, int rating)
    {
        _FullName = fullName;
        _Number = number;
        _Rating = rating;
    }

    public override string ToString()
    {
        return $"Сотрудник {FullName}: Табельный номер - {Number}," +
               $" Должность - {Position}, Почасовая ставка - {HourlyRate}";
    }
}