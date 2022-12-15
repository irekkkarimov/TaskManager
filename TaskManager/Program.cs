using System.Data.Common;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using TaskManager;

TaskManagerApp taskManager = new TaskManagerApp();
taskManager.Init();
bool exit = false;

static void ToClosePage()
{
    Console.WriteLine("Нажмите любую клавишу чтобы выйти в меню");
    Console.ReadKey();
    Console.Clear();
}
while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("***********************************");
    Console.WriteLine("Выберите пункт меню:");
    Console.WriteLine("1. Просмотреть клиентов");
    Console.WriteLine("2. Просмотреть сотрудников");
    Console.WriteLine("3. Просмотреть проекты");
    Console.WriteLine("4. Создать проект");
    Console.WriteLine("5. Выйти");

    var k = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (k)
    {
        case 1:
        {
            taskManager.PrintCustomers();
            ToClosePage();
            break;
        }
        case 2:
        {
            taskManager.PrintEmployees();
            ToClosePage();
            break;
        }
        case 3:
        {
            taskManager.PrintProjectsTitles();
            Console.WriteLine("\n*********************************");
            Console.WriteLine("\n1. Просмотреть подробности проекта");
            Console.WriteLine("2. Просмотреть задачи к проекту");
            var l = int.Parse(Console.ReadLine());
            Console.Clear();
            
            Console.WriteLine("Введите номер проекта");
            taskManager.PrintProjectsTitles();
            var i = int.Parse(Console.ReadLine());
            Console.Clear();
            
            switch (l)
            {
                case 1:
                {
                    Console.WriteLine(taskManager.Projects[i - 1]);
                    Console.WriteLine("\n*******************************\n");
                    ToClosePage();
                    break;
                }
                case 2: 
                {
                    taskManager.PrintTasks(i - 1);
                    Console.WriteLine("1. Просмотреть подробности проекта");
                    Console.WriteLine("2. Выйтив меню");
                    var w = int.Parse(Console.ReadLine());
                    break;
                }
            }

            break;
        }
        case 4:
        {
            Console.WriteLine("Введите название для нового проекта");
            var title = Console.ReadLine();

            Console.WriteLine("Введите ключ");
            var key = int.Parse(Console.ReadLine());

            Console.WriteLine("Выберите клиента");
            taskManager.PrintEmployees();
            var customer = int.Parse(Console.ReadLine());

            taskManager.AddNewProject(title, key, taskManager.Customers[customer - 1]);
            Console.Clear();
            break;
        }
        case 5:
        {
            exit = true;
            break;
        }
    }
}