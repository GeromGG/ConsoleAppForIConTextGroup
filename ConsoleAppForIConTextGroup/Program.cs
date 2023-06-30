using Newtonsoft.Json;
using System.Globalization;

namespace ConsoleAppForIConTextGroup
{
    public class Program
    {
        public static readonly string FilePath = "employees.json";
        public static readonly CultureInfo Cultures = new CultureInfo("en-US");

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Не указаны аргументы командной строки.");
                return;
            }

            var employees = new List<Employee>();

            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    var resultDeserialize = JsonConvert.DeserializeObject<List<Employee>>(json);
                    if (resultDeserialize is not null)
                    {
                        employees = resultDeserialize;
                    }
                }

                string operation = args[0];

                if (employees.Count == 0 && operation != "-add")
                {
                    Console.WriteLine("Файл пустой или отсутствует.");
                    return;
                }

                switch (operation)
                {
                    case "-add":
                        Add(args, employees);
                        break;

                    case "-update":
                        Update(args, employees);
                        break;

                    case "-get":
                        Get(args, employees);
                        break;

                    case "-delete":
                        Delete(args, employees);
                        break;

                    case "-getall":
                        GetAll(employees);
                        break;

                    default:
                        Console.WriteLine("Неверная операция.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка:");
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetValueFromArgument(string arg)
        {
            return arg.Split(':')[1];
        }

        private static void SaveEmployeesToFile(List<Employee> employees, string filePath)
        {
            string json = JsonConvert.SerializeObject(employees);
            File.WriteAllText(filePath, json);
        }

        public static void Add(string[] args, List<Employee> employees)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Недостаточно аргументов для операции -add.");
                return;
            }

            try
            {
                if (!File.Exists(FilePath))
                {
                    employees = new List<Employee>(); // Создание нового списка сотрудников
                    Console.WriteLine("Файл не существует. Создан новый файл.");
                }

                string firstName = GetValueFromArgument(args[1]);
                string lastName = GetValueFromArgument(args[2]);
                string salaryValue = GetValueFromArgument(args[3]);

                if (!decimal.TryParse(salaryValue, NumberStyles.Number, Cultures, out decimal salaryPerHour))
                {
                    Console.WriteLine("Неверный формат значения аргумента Salary.");
                    return;
                }

                int maxId = employees.Count > 0 ? employees.Max(e => e.Id) : 0;
                int newId = maxId + 1;
                var newEmployee = new Employee(newId, firstName, lastName, salaryPerHour);
                employees.Add(newEmployee);

                SaveEmployeesToFile(employees, FilePath);
                Console.WriteLine("Запись успешно добавлена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении записи:");
                Console.WriteLine(ex.Message);
            }
        }

        public static void Update(string[] args, List<Employee> employees)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Недостаточно аргументов для операции -update.");
                return;
            }

            try
            {
                if (!int.TryParse(GetValueFromArgument(args[1]), out int updateId))
                {
                    Console.WriteLine("Неверный формат значения аргумента Id.");
                    return;
                }

                Employee employeeToUpdate = employees.FirstOrDefault(e => e.Id == updateId);

                if (employeeToUpdate == null)
                {
                    Console.WriteLine("Сотрудник с указанным Id не найден.");
                    return;
                }

                for (int i = 2; i < args.Length; i++)
                {
                    string[] parts = args[i].Split(':');

                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Неверный формат аргумента для операции -update.");
                        return;
                    }

                    var field = parts[0];
                    var value = parts[1];

                    switch (field.ToLower())
                    {
                        case "firstname":
                            employeeToUpdate.FirstName = value;
                            break;
                        case "lastname":
                            employeeToUpdate.LastName = value;
                            break;
                        case "salary":
                            decimal salaryPerHour = Convert.ToDecimal(value, Cultures);
                            employeeToUpdate.SalaryPerHour = salaryPerHour;
                            break;
                        default:
                            Console.WriteLine("Неверное поле для обновления.");
                            return;
                    }
                }

                SaveEmployeesToFile(employees, FilePath);
                Console.WriteLine("Запись успешно обновлена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обновлении записи:");
                Console.WriteLine(ex.Message);
            }
        }

        public static void Delete(string[] args, List<Employee> employees)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Недостаточно аргументов для операции -delete.");
                return;
            }

            try
            {
                if (!int.TryParse(GetValueFromArgument(args[1]), out int deleteId))
                {
                    Console.WriteLine("Неверный формат значения аргумента Id.");
                    return;
                }

                Employee employeeToDelete = employees.FirstOrDefault(e => e.Id == deleteId);

                if (employeeToDelete == null)
                {
                    Console.WriteLine("Сотрудник с указанным Id не найден.");
                    return;
                }

                employees.Remove(employeeToDelete);
                SaveEmployeesToFile(employees, FilePath);
                Console.WriteLine("Запись успешно удалена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при удалении записи:");
                Console.WriteLine(ex.Message);
            }
        }

        public static void Get(string[] args, List<Employee> employees)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Недостаточно аргументов для операции -get.");
                return;
            }

            try
            {
                if (!int.TryParse(GetValueFromArgument(args[1]), out int getId))
                {
                    Console.WriteLine("Неверный формат значения аргумента Id.");
                    return;
                }

                Employee employee = employees.FirstOrDefault(e => e.Id == getId);

                if (employee == null)
                {
                    Console.WriteLine("Сотрудник с указанным Id не найден.");
                    return;
                }

                Console.WriteLine($"Информация о сотруднике:");
                Console.WriteLine($"\tId: {employee.Id}");
                Console.WriteLine($"\tИмя: {employee.FirstName}");
                Console.WriteLine($"\tФамилия: {employee.LastName}");
                Console.WriteLine($"\tЗарплата в час: {employee.SalaryPerHour.ToString(Cultures)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении записи:");
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAll(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("В файле нет записей о сотрудниках.");
                return;
            }

            Console.WriteLine("Информация о всех сотрудниках:");

            foreach (Employee emp in employees)
            {
                Console.WriteLine($"\tId: {emp.Id}");
                Console.WriteLine($"\tИмя: {emp.FirstName}");
                Console.WriteLine($"\tФамилия: {emp.LastName}");
                Console.WriteLine($"\tЗарплата в час: {emp.SalaryPerHour.ToString(Cultures)}");
                Console.WriteLine();
            }
        }
    }
}