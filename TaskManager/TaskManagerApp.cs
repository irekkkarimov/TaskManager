using Microsoft.VisualBasic;

namespace TaskManager;

public class TaskManagerApp
{
    public List<Customer> Customers = new List<Customer>();
    public List<Employee> Employees = new List<Employee>();
    public List<Position> Positions = new List<Position>();
    public List<Project> Projects = new List<Project>();

    public TaskManagerApp()
    {
    }

    public void Init()
    {
        Customers.Clear();
        Customers.Add(new Customer("FirstCustomer@gmail.ru",
            "Иванов Иван Иванович", "+89870000001", "Bars Group"));
        Customers.Add(new Customer("SecondCustomer@mail.ru",
            "Андреев Андрей Андреевич", "+79880000002", "Tinkoff Bank"));
        Customers.Add(new Customer("ThirdCustomer@yandex.ru",
            "Владиславов Владислав Владиславович", "+89780000003", "Apple"));
        
        Positions.Clear();
        Positions.Add(new Position(300, 01, "Junior-Developer"));
        Positions.Add(new Position(600, 02, "Middle-Developer"));
        Positions.Add(new Position(900, 03, "Senior-Developer"));
        Positions.Add(new Position(1000, 05, "Team-Leader"));
        
        Employees.Clear();
        Employees.Add(new Employee("Дмитриенко Алексей Петрович", 110001, 1, Positions[0]));
        Employees.Add(new Employee("Иванов Дмитрий Иванович", 110002, 2, Positions[1]));
        Employees.Add(new Employee("Андреев Владислав Иванович", 110003, 3, Positions[2]));
        Employees.Add(new Employee("Владимиров Никита Андреевич", 110004, 4, Positions[3]));
        Employees.Add(new Employee("Андреев Владимир Петрович", 110005, 5, Positions[1]));
        
    }

    public void PrintCustomers()
    {
        Console.WriteLine("Список клиентов");
        int c = 1;
        foreach (var customer in Customers)
        {
            Console.WriteLine($"{c}. {customer}");
            c++;
        }
    }

    public void PrintEmployees()
    {
        Console.WriteLine("Список сотрудников");
        int c = 1;
        foreach (var employee in Employees)
        {
            Console.WriteLine($"{c}. {employee}");
            c++;
        }
    }

    public void PrintProjects()
    {
        Console.WriteLine("Список проектов");
        int c = 1;
        foreach (var project in Projects)
        {
            Console.WriteLine($"{c}. {project}");
            c++;
        }
    }

    public void PrintProjectsTitles()
    {
        Console.WriteLine("Список проектов:");
        int c = 1;
        foreach (var project in Projects)
        {
            Console.WriteLine($"{c}. {project.Title}");
            c++;
        }
    }

    public void PrintTasks(int i)
    {
        int c = 1;
        Console.WriteLine($"Список задач к проекту {Projects[i].Title}:");
        foreach (var task in Projects[i].tasks)
        {
            Console.WriteLine($"{c} Задача");
            c++;
        }
    }

    public void AddNewProject(string title, int key, Customer customer)
    {
        Projects.Add(new Project(title, key, customer));
    }

    public void AddNewTask(string description, int number, Employee employee, bool billable, int projectId, DateOnly dueDate)
    {
        Projects[projectId].tasks.Add(new Task() {Description = description, Number = number, Employee = employee, Billable = billable, DueDate = dueDate});
    }
}