namespace TaskManager;

public class Task
{
    private bool _Billable;
    private DateOnly _CloseDate;
    private string _Description;
    private DateOnly _DueDate;
    private double _HoursSpent;
    private int _Number;
    private Employee _employee;
    private double _TaskCost;

    public bool Billable
    {
        get => _Billable;
        set => _Billable = value;
    }

    public DateOnly CloseDate
    {
        get => _CloseDate;
        set => _CloseDate = value;
    }

    public string Description
    {
        get => _Description;
        set => _Description = value;
    }

    public DateOnly DueDate
    {
        get => _DueDate;
        set => _DueDate = value;
    }

    public double HoursSpent
    {
        get => _HoursSpent;
        set => _HoursSpent = value;
    }

    public int Number
    {
        get => _Number;
        set => _Number = value;
    }

    public Employee Employee
    {
        get => _employee;
        set => _employee = value;
    }

    public double TaskCost
    {
        get => _TaskCost;
        set => _TaskCost = value;
    }

    public override string ToString()
    {
        return $"Задача {_Number}: Дата завершения - {CloseDate}, Ответственный сотрудник - {Employee},\n" +
               $"Срок выполнения - {DueDate}, Время выполнения - {HoursSpent}, Стоимость задачи - {TaskCost} рублей, {(Billable ? "Задача отдельно оплачивается заказчиком" : "")}, \n" +
               $"Описание: {Description}";
    }
}