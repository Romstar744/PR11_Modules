using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ПР11
{
	
	public struct Work
	{
		public int kod; // поле кода сотрудника
		public double zarabotok; // поле заработной платы
		public string name; // поле имя сотрудника
		public string surname; // поле фамилия сотрудника
		public string cardNumber; // поле номер карты сотрудника
		public string phoneNumber; // поле номер телефона сотрудника
	}

	class Program
	{
		enum Name { Иван, Петр, Ирина, Ольга, Ян }
		enum Surname { Сидоров, Андреев, Иванова, Выходова, Юрин }

		private static Type t1 = typeof(Name);
		private static Type t2 = typeof(Surname);

		static void Main(string[] args)
		{
			int k = 0;
			Work[] w = new Work[5]; // объявление структурной переменной и выделение памяти для массива
			Name[] names;
			// Получить значения констант из перечисления Name
			names = Enum.GetValues(typeof(Name)).Cast<Name>().ToArray();
			Surname[] surnames;
			// Получить значения констант из перечисления Surname
			surnames = Enum.GetValues(typeof(Surname)).Cast<Surname>().ToArray();

			Random r = new Random();
			for (int i = 0; i< w.Length; i++)
			{
				w[i].kod = i;

				if (i < names.Length && i < surnames.Length)
				{
					// вводим данные сотрудников: Имя и Фамилия
					Console.WriteLine("Код сотрудника №" + (i + 1) + ": Имя: " + names[i]);
					w[i].name = names[i].ToString();
					Console.WriteLine("Код сотрудника №" + (i + 1) + ": Фамилия: " + surnames[i].ToString() + "\n");
					w[i].surname = surnames[i].ToString();
				}



				// вводим данные сотрудников: Имя и Фамилия
				//Console.Write(" Код сотрудника №" + (i+1)+": Имя: "+ names[i].ToString());
				//w[i].name = Console.ReadLine();
                //Console.Write(" Код сотрудника №" + (i + 1) + ": Фамилия: " + surnames[i].ToString()+ "\n");
				//w[i].surname = Console.ReadLine();



				// формируем заработную плату (числа случайным образом в диапазоне от 20000 до 30000)
				w[i].zarabotok = r.Next(200000, 300000) / 10.0;

				// вводим данные о номере карты и номере телефона
				Console.WriteLine("Код сотрудника №" + (i + 1) + ": Номер карты: ");
				w[i].cardNumber = Console.ReadLine();

				Console.WriteLine("Код сотрудника №" + (i + 1) + ": Номер телефона: ");
				w[i].phoneNumber = Console.ReadLine();
			}
            // Вывод массива строк в цикле
            Console.WriteLine("\n Результат:");
			for (int i = 0; i< w.Length;i++)
			{
				Console.WriteLine("Код сотрудника №" + (i + 1) + ": " + w[i].name + " " + w[i].surname +
								  " Зарплата - " + w[i].zarabotok + " Номер карты - " + w[i].cardNumber +
								  " Номер телефона - " + w[i].phoneNumber);
			}

			Console.WriteLine("\n Проверка корректности ввода:");
			foreach (var employee in w)
			{
				ValidateCardNumber(employee.cardNumber);
				ValidatePhoneNumber(employee.phoneNumber);
			}

			// Определение количества сотрудников с зарплатой больше прожиточного минимума
			Console.WriteLine("\n Количество сотрудников с зарплатой больше 20000 рублей: " +
							 w.Count(emp => emp.zarabotok > 20000));

			// Вывод фамилий сотрудников, начинающихся на А
			Console.WriteLine("\n Фамилии сотрудников, начинающихся на А:");
			foreach (var employee in w.Where(emp => emp.surname != null && emp.surname.StartsWith("А")))
			{
				Console.WriteLine(employee.surname);
			}

			// Вывод списка фамилий, отсортированных по алфавиту
			Console.WriteLine("\n Список фамилий, отсортированных по алфавиту:");
			foreach (var employee in w.OrderBy(emp => emp.surname))
			{
				Console.WriteLine(employee.surname);
			}

			Console.ReadKey();
        }

		static void ValidateCardNumber(string cardNumber)
		{
			// Регулярное выражение для номера карты (пример)
			string pattern = @"^\d{4}-\d{4}-\d{4}-\d{4}$";

			if (Regex.IsMatch(cardNumber, pattern))
			{
				Console.WriteLine($"Номер карты {cardNumber} введен корректно.");
			}
			else
			{
				Console.WriteLine($"Некорректный номер карты: {cardNumber}");
			}
		}

		static void ValidatePhoneNumber(string phoneNumber)
		{
			// Регулярное выражение для номера телефона (пример)
			string pattern = @"^\d{3}-\d{2}-\d{2}$";

			if (Regex.IsMatch(phoneNumber, pattern))
			{
				Console.WriteLine($"Номер телефона {phoneNumber} введен корректно.");
			}
			else
			{
				Console.WriteLine($"Некорректный номер телефона: {phoneNumber}");
			}
		}
	}
}