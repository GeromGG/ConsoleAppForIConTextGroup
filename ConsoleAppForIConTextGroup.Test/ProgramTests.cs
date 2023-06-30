using NUnit.Framework;

namespace ConsoleAppForIConTextGroup.Test
{
    [TestFixture]
    public class ProgramTests
    {
        private string testFilePath;
        private List<Employee> testEmployees;

        [SetUp]
        public void Setup()
        {
            // Инициализация тестовых данных
            testFilePath = "test_employees.txt";
            testEmployees = new List<Employee>
                {
                    new Employee(0, "John", "Doe", 100.50m),
                    new Employee(1, "Alice", "Smith", 75.25m),
                    new Employee(2, "Michael", "Johnson", 80.0m),
                    new Employee(3, "Emily", "Brown", 95.75m),
                    new Employee(4, "David", "Wilson", 110.0m),
                    new Employee(5, "Sarah", "Taylor", 120.50m),
                    new Employee(6, "James", "Anderson", 105.25m),
                    new Employee(7, "Olivia", "Clark", 90.0m),
                    new Employee(8, "Daniel", "Lee", 115.75m),
                    new Employee(9, "Sophia", "Martinez", 130.0m),
                    new Employee(10, "Matthew", "Hernandez", 85.50m),
                    new Employee(11, "Emma", "Lopez", 100.25m),
                    new Employee(12, "Joseph", "Gonzalez", 70.0m),
                    new Employee(13, "Mia", "Perez", 85.75m),
                    new Employee(14, "Andrew", "Robinson", 120.0m),
                    new Employee(15, "Isabella", "Hall", 125.50m),
                    new Employee(16, "Christopher", "Young", 110.25m),
                    new Employee(17, "Abigail", "King", 95.0m),
                    new Employee(18, "Ethan", "Wright", 105.75m),
                    new Employee(19, "Charlotte", "Turner", 140.0m)
                };
        }

        [TearDown]
        public void Cleanup()
        {
            // Удаление созданного тестового файла после каждого теста
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void Update_WithValidArguments_ShouldUpdateEmployee()
        {
            // Arrange
            var args = new string[] { "-update", "Id:1", "firstname:Mike", "lastname:Smith", "salary:20" };
            var expectedFirstName = "Mike";
            var expectedLastName = "Smith";
            var expectedSalary = 20m;

            // Act
            Program.Update(args, testEmployees);
            var updatedEmployee = testEmployees.Find(e => e.Id == 1);

            // Assert
            Assert.IsNotNull(updatedEmployee);
            Assert.AreEqual(expectedFirstName, updatedEmployee.FirstName);
            Assert.AreEqual(expectedLastName, updatedEmployee.LastName);
            Assert.AreEqual(expectedSalary, updatedEmployee.SalaryPerHour);
        }

        [Test]
        public void Update_WithInvalidId_ShouldNotUpdateEmployee()
        {
            // Arrange
            var args = new string[] { "-update", "Id:23", "firstname:Mike", "lastname:Smith", "salary:20" };

            // Act
            Program.Update(args, testEmployees);
            var updatedEmployee = testEmployees.Find(e => e.Id == 23);

            // Assert
            Assert.IsNull(updatedEmployee);
        }

        [Test]
        public void Update_WithInvalidArguments_ShouldNotUpdateEmployee()
        {
            // Arrange
            var args = new string[] { "-update", "Id:0", "invalidargument" };

            // Act
            Program.Update(args, testEmployees);
            var updatedEmployee = testEmployees.Find(e => e.Id == 0);

            // Assert
            Assert.IsNotNull(updatedEmployee);
            // Проверка, что значения не изменились
            Assert.AreEqual("John", updatedEmployee.FirstName);
            Assert.AreEqual("Doe", updatedEmployee.LastName);
            Assert.AreEqual(100.50m, updatedEmployee.SalaryPerHour);
        }
    }
}
