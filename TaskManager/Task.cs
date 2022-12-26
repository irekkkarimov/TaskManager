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

    // public bool DateComparer()
    // {
    //     bool firstComparison = int.Parse(CloseDate.Substring(6, 2)) > int.Parse(DueDate.Substring(6, 2));
    //     bool secondComparison;
    //     bool thirComparison;
    //     if (int.Parse(CloseDate.Substring(6, 2)) > int.Parse(DueDate.Substring(6, 2)))
    //     {
    //         return false;
    //     }
    //     if (int.Parse(CloseDate.Substring(6, 2)) == int.Parse(DueDate.Substring(6, 2)))
    //     {
    //         if (int.Parse(CloseDate.Substring(3, 2)) > int.Parse(DueDate.Substring(3, 2)))
    //         {
    //             return false;
    //         }
    //
    //         if (int.Parse(CloseDate.Substring(3, 2)) == int.Parse(DueDate.Substring(3, 2)))
    //         {
    //             if (int.Parse(CloseDate.Substring(0, 2)) > int.Parse(DueDate.Substring(0, 2)))
    //                 return false;
    //         }
    //     }

        // return true;
    // }

    public void TaskCostCalculator()
    {
        var comparison = DueDate.CompareTo(CloseDate);
        var yearsComparison = DueDate.Year.CompareTo(CloseDate.Year);
        var monthsDifference = DueDate.Month - CloseDate.Month;
        var daysDifference = CloseDate.Day - DueDate.Day;
        if (comparison == 1) TaskCost = Employee.HourlyRate * HoursSpent;
        else if (comparison == 0)
        {
            TaskCost = Employee.HourlyRate * HoursSpent;
        }
        else
        {
            if (yearsComparison == 1)
                TaskCost = Employee.HourlyRate * HoursSpent * 0.75;
            else
            {
                if (monthsDifference > 1) TaskCost = Employee.HourlyRate * HoursSpent * 0.75;
                else if (monthsDifference == 0)
                {
                    if (daysDifference >= 25) TaskCost = Employee.HourlyRate * HoursSpent * 0.75;
                    else
                    {
                        TaskCost = Employee.HourlyRate * HoursSpent * (1 - 0.01 * daysDifference);
                    }
                }
                else if (monthsDifference == 1)
                {
                    daysDifference = daysDifference - 30;
                    if (daysDifference >= 25) TaskCost = Employee.HourlyRate * HoursSpent * 0.75;
                    else
                    {
                        TaskCost = Employee.HourlyRate * HoursSpent * (1 - 0.01 * daysDifference);
                    }
                }
            }
        }
    }

    public override string ToString()
    {
        return $"Задача {_Number}: Дата завершения - {CloseDate}, Ответственный сотрудник - {Employee},\n" +
               $"Срок выполнения - {DueDate}, Время выполнения - {HoursSpent}, {(Billable ? $"Стоимость задачи - {Math.Round(TaskCost)} рублей, " : "")}{(Billable ? "Задача отдельно оплачивается заказчиком" : "")}, \n" +
               $"Описание: {Description}";
    }
}