namespace TaskManager;

public class TaskManagerApp
{
    public List<Customer> Customers = new List<Customer>();
    public List<Employee> Employees = new List<Employee>();
    public List<Task> Tasks = new List<Task>();
    public List<Position> Positions = new List<Position>();
    public List<Project> Projects = new List<Project>();

    public TaskManagerApp()
    {
    }

    public void Init()
    {
        Customers.Clear();
        Customers.Add(new Customer("FirstCustomer@gmail.ru",
            "Иванов Иван Иванович", "+89870000001", "01"));
        Customers.Add(new Customer("SecondCustomer@mail.ru",
            "Андреев Андрей Андреевич", "+79880000002", "02"));
        Customers.Add(new Customer("ThirdCustomer@yandex.ru",
            "Владиславов Владислав Владиславович", "+89780000003", "03"));
        
        Positions.Clear();
        Positions.Add(new Position(300, 01, "Junior-Developer"));
        Positions.Add(new Position(600, 02, "Middle-Developer"));
        Positions.Add(new Position(900, 03, "Senior-Developer"));
        Positions.Add(new Position(1000, 05, "Team-Leader"));
        
        Employees.Clear();
        Employees.Add(new Employee("Дмитриенко Алексей Петрович", 110001, 1));
        Employees.Add(new Employee("Иванов Дмитрий Иванович", 110002, 2));
        Employees.Add(new Employee("Андреев Владислав Иванович", 110003, 3));
        Employees.Add(new Employee("Владимиров Никита Андреевич", 110004, 4));
        Employees.Add(new Employee("Андреев Владимир Петрович", 110005, 5));
        
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
        Console.WriteLine($"Список задач к проекту {Projects[i]}:");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"{c}. {task.Number}");
            c++;
        }
    }

    public void AddNewProject(string title, int key, Customer customer)
    {
        Projects.Add(new Project(title, key, customer));
    }
}