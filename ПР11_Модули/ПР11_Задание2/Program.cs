using System;
using System.Collections;

namespace ПР11_2
{
    public struct Work
    {
        public string kod;
        public string fullName;
        public string position;
        public uint salary;
        public int experience;
    }

    class Program
    {
        static void Main()
        {
            ArrayList employees = new ArrayList();

            // Заполнение начальных данных
            employees.Add(new Work { kod = "001", fullName = "Иванов Иван", position = "повар", salary = 25000, experience = 3 });
            employees.Add(new Work { kod = "002", fullName = "Петров Петр", position = "кондитер", salary = 15842, experience = 2 });
            employees.Add(new Work { kod = "003", fullName = "Сидорова Ирина", position = "пекарь", salary = 47852, experience = 4 });
            employees.Add(new Work { kod = "004", fullName = "Кузнецова Ольга", position = "тестомес", salary = 25871, experience = 1 });
            employees.Add(new Work { kod = "005", fullName = "Федоров Ян", position = "кондитер", salary = 35890, experience = 5 });

            DisplayEmployees(employees);

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить запись");
                Console.WriteLine("2. Удалить запись");
                Console.WriteLine("3. Найти количество сотрудников по должности");
                Console.WriteLine("4. Вывести данные в обратном порядке");
                Console.WriteLine("5. Найти и вывести сотрудников со стажем менее 5 лет и окладом выше среднего");
                Console.WriteLine("6. Выйти из программы");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(employees);
                        DisplayEmployees(employees);
                        break;

                    case "2":
                        RemoveEmployee(employees);
                        DisplayEmployees(employees);
                        break;

                    case "3":
                        CountEmployeesByPosition(employees);
                        break;

                    case "4":
                        DisplayEmployeesReversed(employees);
                        break;

                    case "5":
                        DisplayHighSalaryLowExperienceEmployees(employees);
                        break;

                    case "6":
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, повторите.");
                        break;
                }
            }
        }

        static void DisplayEmployees(ArrayList employees)
        {
            Console.WriteLine("\nТекущее содержимое списка сотрудников:\n");

            foreach (Work employee in employees)
            {
                Console.WriteLine($"{employee.kod} {employee.fullName} {employee.position} {employee.salary} {employee.experience}");
            }
        }

        static void AddEmployee(ArrayList employees)
        {
            Console.Write("\nВведите код сотрудника: ");
            string kod = Console.ReadLine();

            Console.Write("Введите Ф.И.: ");
            string fullName = Console.ReadLine();

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            Console.Write("Введите оклад: ");
            uint salary = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Введите стаж: ");
            int experience = Convert.ToInt32(Console.ReadLine());

            employees.Add(new Work { kod = kod, fullName = fullName, position = position, salary = salary, experience = experience });

            Console.WriteLine("Запись добавлена успешно.");
        }

        static void RemoveEmployee(ArrayList employees)
        {
            Console.Write("\nВведите код уволенного сотрудника: ");
            string kod = Console.ReadLine();

            int index = FindEmployeeIndexByCode(employees, kod);

            if (index != -1)
            {
                Console.WriteLine($"\nУволенный сотрудник: {((Work)employees[index]).fullName}\n");

                employees.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Сотрудник с таким кодом не найден.");
            }
        }

        static void CountEmployeesByPosition(ArrayList employees)
        {
            Console.Write("\nВведите должность для подсчета: ");
            string position = Console.ReadLine();

            int count = 0;

            foreach (Work employee in employees)
            {
                if (employee.position.Equals(position, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество сотрудников на должности {position}: {count}");
        }

        static void DisplayEmployeesReversed(ArrayList employees)
        {
            Console.WriteLine("\nСписок сотрудников в обратном порядке:");

            for (int i = employees.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"{((Work)employees[i]).kod} {((Work)employees[i]).fullName} " +
                                  $"{((Work)employees[i]).position} {((Work)employees[i]).salary} {((Work)employees[i]).experience}");
            }
        }

        static void DisplayHighSalaryLowExperienceEmployees(ArrayList employees)
        {
            double averageSalary = CalculateAverageSalary(employees);

            Console.WriteLine($"\nСотрудники со стажем менее 5 лет и окладом выше среднего ({averageSalary}):");

            foreach (Work employee in employees)
            {
                if (employee.experience < 5 && employee.salary > averageSalary)
                {
                    Console.WriteLine($"{employee.fullName} {employee.salary} {employee.experience} лет");
                }
            }
        }

        static double CalculateAverageSalary(ArrayList employees)
        {
            double totalSalary = 0;

            foreach (Work employee in employees)
            {
                totalSalary += employee.salary;
            }

            return totalSalary / employees.Count;
        }

        static int FindEmployeeIndexByCode(ArrayList employees, string code)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (((Work)employees[i]).kod.Equals(code, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
