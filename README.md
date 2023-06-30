### Тестовая задача: необходимо создать консольное приложение, обрабатывающее текстовый файл, содержащий список сотрудников в формате JSON. Формат записи о сотруднике:

- столбец Id, тип в C# - int;
- столбец FirstName, тип в C# - string;
- столбец LastName, тип в C# - string;
- столбец SalaryPerHour, тип в C# - decimal.

Приложение принимает входные аргументы (в string[] args метода Main), и на их основе
выполняет соответствующую операцию.

Доступны следующие аргументы и операции:

1. -**add FirstName:John LastName:Doe Salary:100.50.**
Добавляет в файл новую запись. Поля FirstName, LastName и SalaryPerHour заполняются из аргументов (John, Doe, 100.50). Поле Id генерируется автоматически по следующему принципу: самое большое значение столбца Id, из всех имеющихся в файле, + 1.
2. **-update Id:123 FirstName:James**
Обновляет запись с Id=123, меняет в нем поле FirstName на указанное (James). Таким образом можно обновлять любые поля, кроме Id. Если не существует записи с таким Id, в консоль выводится строка, сообщающая об ошибке (текст ошибки - на усмотрение разработчика).
3. **-get Id:123**
Выводит в консоль строку формата «Id = {Id}, FirstName = {FirstName}, LastName = {LastName}, SalaryPerHour = {SalaryPerHour}», вместо {Id}, {FirstName}, {LastName}, {SalaryPerHour} должны быть подставлены соответствующие поля из записи с Id=123 из файла. Если не существует записи с таким Id, в консоль выводится строка, сообщающая об ошибке (текст ошибки - на усмотрение разработчика).
4. **-delete Id:123**
Удаляет запись с Id=123 из файла. Если не существует записи с таким Id, в консоль выводится строка, сообщающая об ошибке (текст ошибки - на усмотрение разработчика).
5. **-getall**

Возвращает список всех сотрудников (формат аналогичен приведенному в описании аргумента -get).

**Дополнительные условия:**

1. Один из методов, на выбор разработчика, должен быть протестирован unit-тестами
(любой тестовый фреймворк);
2. Наибольшее внимание следует уделить качеству коду.

###Пример JSON файла для тестов:

[
  {
    "Id": 0,
    "FirstName": "John",
    "LastName": "Doe",
    "SalaryPerHour": 100.50
  },
  {
    "Id": 1,
    "FirstName": "Alice",
    "LastName": "Smith",
    "SalaryPerHour": 75.25
  },
  {
    "Id": 2,
    "FirstName": "Michael",
    "LastName": "Johnson",
    "SalaryPerHour": 80.0
  },
  {
    "Id": 3,
    "FirstName": "Emily",
    "LastName": "Brown",
    "SalaryPerHour": 95.75
  },
  {
    "Id": 4,
    "FirstName": "David",
    "LastName": "Wilson",
    "SalaryPerHour": 110.0
  },
  {
    "Id": 5,
    "FirstName": "Sarah",
    "LastName": "Taylor",
    "SalaryPerHour": 120.50
  },
  {
    "Id": 6,
    "FirstName": "James",
    "LastName": "Anderson",
    "SalaryPerHour": 105.25
  },
  {
    "Id": 7,
    "FirstName": "Olivia",
    "LastName": "Clark",
    "SalaryPerHour": 90.0
  },
  {
    "Id": 8,
    "FirstName": "Daniel",
    "LastName": "Lee",
    "SalaryPerHour": 115.75
  },
  {
    "Id": 9,
    "FirstName": "Sophia",
    "LastName": "Martinez",
    "SalaryPerHour": 130.0
  },
  {
    "Id": 10,
    "FirstName": "Matthew",
    "LastName": "Hernandez",
    "SalaryPerHour": 85.50
  },
  {
    "Id": 11,
    "FirstName": "Emma",
    "LastName": "Lopez",
    "SalaryPerHour": 100.25
  },
  {
    "Id": 12,
    "FirstName": "Joseph",
    "LastName": "Gonzalez",
    "SalaryPerHour": 70.0
  },
  {
    "Id": 13,
    "FirstName": "Mia",
    "LastName": "Perez",
    "SalaryPerHour": 85.75
  },
  {
    "Id": 14,
    "FirstName": "Andrew",
    "LastName": "Robinson",
    "SalaryPerHour": 120.0
  },
  {
    "Id": 15,
    "FirstName": "Isabella",
    "LastName": "Hall",
    "SalaryPerHour": 125.50
  },
  {
    "Id": 16,
    "FirstName": "Christopher",
    "LastName": "Young",
    "SalaryPerHour": 110.25
  },
  {
    "Id": 17,
    "FirstName": "Abigail",
    "LastName": "King",
    "SalaryPerHour": 95.0
  },
  {
    "Id": 18,
    "FirstName": "Ethan",
    "LastName": "Wright",
    "SalaryPerHour": 105.75
  },
  {
    "Id": 19,
    "FirstName": "Charlotte",
    "LastName": "Turner",
    "SalaryPerHour": 140.0
  }
]
