using System.Data.Common;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using TaskManager;

TaskManagerApp taskManager = new TaskManagerApp();
taskManager.Init();
var separatingLine = "***********************************";
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
    Console.WriteLine(separatingLine);
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
            Console.WriteLine(separatingLine);
            Console.WriteLine("1. Просмотреть подробности проекта");
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
                    Console.WriteLine(separatingLine);
                    ToClosePage();
                    break;
                }
                case 2: 
                {
                    if (taskManager.Projects[i - 1].tasks.Count == 0)
                    {
                        Console.WriteLine("Нет задач к проекту");
                    }
                    else
                    {
                        taskManager.PrintTasks(i - 1);
                    }

                    Console.WriteLine(separatingLine);
                        Console.WriteLine("1. Просмотреть описание задачи");
                        Console.WriteLine("2. Создать новую задачу");
                        Console.WriteLine("3. Редактировать задачу");
                        Console.WriteLine("4. Удалить задачу");
                        var w = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (w)
                        {


                            case 1:
                            {
                                Console.WriteLine("Введите номер задачи, описание которой хотите посмотреть:\n");
                                if (taskManager.Projects[i - 1].tasks.Count == 0)
                                {
                                    Console.WriteLine("Нет задач к проекту"); Console.WriteLine(separatingLine); ToClosePage();
                                    break;
                                }
                                else
                                {
                                    taskManager.PrintTasks(i - 1);
                                }

                                var e = int.Parse(Console.ReadLine());
                                Console.WriteLine(taskManager.Projects[i - 1].tasks[e - 1]);
                                ToClosePage();
                                break;
                            }

                            case 2:
                            {
                                Console.WriteLine("Введите описание задачи");
                                var description = Console.ReadLine();

                                var number = taskManager.Projects[i - 1].tasks.Count + 1;

                                Console.WriteLine("Выберите ответственного сотрудника");
                                taskManager.PrintEmployees();
                                var employee = taskManager.Employees[int.Parse(Console.ReadLine()) - 1];

                                Console.WriteLine("Будет ли задача отдельно оплачиваться клиентов?\n1. Да\n2. Нет");
                                var choose = int.Parse(Console.ReadLine());
                                var billable = choose == 1;
                                
                                Console.WriteLine("Введите дату в формате МЕС Д, ГГГГ. Например 'Jan 1, 2009'");
                                var dueDate = DateOnly.Parse(Console.ReadLine());
                                taskManager.AddNewTask(description, number, employee, billable, i - 1, dueDate);
                                Console.Clear();
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("Введите номер задачи, которую хотите отредактировать:\n");
                                if (taskManager.Projects[i - 1].tasks.Count == 0)
                                {
                                    Console.WriteLine("Нет задач к проекту"); Console.WriteLine(separatingLine); ToClosePage();
                                    break;
                                }
                                Console.WriteLine(separatingLine);
                                taskManager.PrintTasks(i - 1);
                                Console.WriteLine(separatingLine);
                                var o = int.Parse(Console.ReadLine());
                                Console.Clear();
                                
                                Console.WriteLine(taskManager.Projects[i - 1].tasks[o - 1]);
                                Console.WriteLine(separatingLine);
                                Console.WriteLine("Что вы хотите отредактировать?");
                                Console.WriteLine("1. Отредактировать описание задачи");
                                Console.WriteLine("2. Изменить ответственного сотрудника");
                                Console.WriteLine("3. Добавить дату завершения работ");
                                Console.WriteLine("4. Ввести, сколько часов потрачено");
                                Console.WriteLine("5. Изменить факт, будет ли задача отдельно оплачиваться сотрудником");
                                var p = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (p)
                                {
                                    case 1:
                                    {
                                        Console.WriteLine("Нынешнее описание:");
                                        Console.WriteLine(taskManager.Projects[i - 1].tasks[o - 1].Description);
                                        Console.WriteLine(separatingLine);
                                        Console.WriteLine("Введите новое описание");
                                        var newDescription = Console.ReadLine();
                                        taskManager.Projects[i - 1].tasks[o - 1].Description = newDescription;
                                        Console.Clear();
                                        Console.WriteLine("Описание было изменено успешно");
                                        Console.WriteLine(separatingLine);
                                        ToClosePage();
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("Нынешний ответственный сотрудник:");
                                        Console.WriteLine(taskManager.Projects[i - 1].tasks[o - 1].Employee);
                                        Console.WriteLine(separatingLine);
                                        Console.WriteLine("Выберите нового сотрудника");
                                        taskManager.PrintEmployees();
                                        var u = int.Parse(Console.ReadLine());
                                        taskManager.Projects[i - 1].tasks[o - 1].Employee =
                                            taskManager.Employees[u - 1];
                                        Console.Clear();
                                        Console.WriteLine("Ответственный сотрудник был изменён успешно");
                                        Console.WriteLine(separatingLine);
                                        ToClosePage();
                                        break;
                                    }
                                    case 3:
                                    {
                                        Console.WriteLine("Введите дату в формате МЕС Д, ГГГГ. Например 'Jan 1, 2009'");
                                        var closeDate = DateOnly.Parse(Console.ReadLine());
                                        taskManager.Projects[i - 1].tasks[o - 1].CloseDate = closeDate;
                                        taskManager.Projects[i - 1].tasks[o - 1].TaskCostCalculator();
                                        Console.Clear();
                                        Console.WriteLine("Дата завершения задачи была успешно добавлена");
                                        Console.WriteLine(separatingLine);
                                        ToClosePage();
                                        break;
                                    }
                                    case 4:
                                    {
                                        Console.WriteLine("Введите, сколько часов было потрачено на задачу:");
                                        var hoursSpent = int.Parse(Console.ReadLine());
                                        taskManager.Projects[i - 1].tasks[o - 1].HoursSpent = hoursSpent;
                                        taskManager.Projects[i - 1].tasks[o - 1].TaskCostCalculator();
                                        Console.Clear();
                                        Console.WriteLine("Вы успешно добавили число потраченных часов");
                                        Console.WriteLine(separatingLine);
                                        ToClosePage();
                                        break;
                                    }
                                    case 5:
                                    {
                                        if (taskManager.Projects[i - 1].tasks[o - 1].Billable)
                                        {
                                            taskManager.Projects[i - 1].tasks[o - 1].Billable = false;
                                            Console.WriteLine("Теперь задача не будет отдельно оплачиваться заказчиком");
                                            Console.WriteLine(separatingLine);
                                            ToClosePage();
                                            break;
                                        }
                                        else
                                        {
                                            taskManager.Projects[i - 1].tasks[o - 1].Billable = true;
                                            Console.WriteLine("Теперь задача будет отдельно оплачиваться заказчиком");
                                            Console.WriteLine(separatingLine);
                                            ToClosePage();
                                            break;
                                        }
                                    }
                                }


                                    break;
                            }
                            case 4:
                            {
                                Console.WriteLine("Введите номер задачи, которую хотите удалить");
                                taskManager.PrintTasks(i - 1);
                                var r = int.Parse(Console.ReadLine());
                                if (r < 0 || r > taskManager.Projects[i - 1].tasks.Count)
                                {
                                    Console.WriteLine("Неверный номер");
                                    ToClosePage();
                                    break;
                                }
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