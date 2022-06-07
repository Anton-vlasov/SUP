using System;
using System.Linq;

namespace SUP.Repository
{
    public partial class Employee
    {
        public String FullName
        {
            get => $"{LastName} {FirstName} {SecondName}"; // вывод ФИО сотрудника
        }

        public String EmployeeTypeString
        {
            get => $"Должность: {EmployeeType.Title}"; // вывод должности сотрудника
        }

        public String Salary
        {
            get => $"Зарплата: {EmployeeType.Salary}"; // вывод зарплаты сотрудника
        }

        public String PerformerTaskCount
        {
            get => $"Задач на выполнение: {Tasks.Where(t => t.TaskState.State != "Завершено").Count()}"; // вывод количества задач сотрудника, которые он выполняет
        }

        public String TesterTaskCount
        {
            get => $"Задач на тестирование: {Tasks1.Where(t => t.TaskState.State != "Завершено").Count()}"; // вывод количества задач сотрудника, которые он тестирует
        }

        public String ProjectsCount
        {
            get => $"Активных проектов: {ProjectWorks.Where(pw => pw.DateEnd == null).Count()}"; //  вывод количества задач сотрудника, за которыми он работает
        }

        public Boolean Border { get; set; } = false;
    }
}
