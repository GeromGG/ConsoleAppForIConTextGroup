﻿namespace ConsoleAppForIConTextGroup
{
    public class Employee
    {
        public Employee(int id, string firstName, string lastName, decimal salaryPerHour)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SalaryPerHour = salaryPerHour;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryPerHour { get; set; }
    }
}
