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
                    if (taskManager.Projects[i - 1].tasks.Count == 0)
                    {
                        Console.WriteLine("Нет задач к проекту");
                        ToClosePage();
                    }
                    else
                    {
                        taskManager.PrintTasks(i - 1);
                        Console.WriteLine("1. Просмотреть описание задачи");
                        Console.WriteLine("2. Создать новую задачу");
                        Console.WriteLine("3. Редактировать задачу");
                        Console.WriteLine("4. Удалить задачу");
                        var w = int.Parse(Console.ReadLine());
                        switch (w)
                        {


                            case 1:
                            {
                                Console.WriteLine("Введите номер задачи, описание которой хотите посмотреть");
                                taskManager.PrintTasks(i - 1);
                                var e = int.Parse(Console.ReadLine());
                                Console.WriteLine(taskManager.Projects[i - 1].tasks[e - 1]);
                                ToClosePage();
                                break;
                            }

                            case 2:
                            {
                                Console.WriteLine("Введите описание задачи");
                                var description = Console.ReadLine();

                                var number = taskManager.Projects[i - 1].tasks.Count;

                                Console.WriteLine("Выберите ответственного сотрудника");
                                taskManager.PrintEmployees();
                                var employee = taskManager.Employees[int.Parse(Console.ReadLine()) - 1];

                                Console.WriteLine("Будет ли задача отдельно оплачиваться клиентов?\n1. Да\n2. Нет");
                                var choose = int.Parse(Console.ReadLine());
                                var billable = choose == 1;
                                taskManager.AddNewTask(description, number, employee, billable, i - 1);
                                Console.Clear();
                                break;
                            }
                            case 3:
                            {
                                break;
                            }
                            case 4:
                            {
                                Console.WriteLine("Введите номер задачи, которую хотите удалить");
                                taskManager.PrintTasks(i - 1);
                                var r = int.Parse(Console.ReadLine());
                                var taskToRemove = taskManager.Projects[i - 1].tasks[r - 1];
                                taskManager.Projects[i - 1].tasks.Remove(taskToRemove);
                                Console.WriteLine("Задача была удалена");
                                ToClosePage();
                                break;
                            }
                        }
                        break;
                    }

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
            taskManager.PrintCustomers();
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