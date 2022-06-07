using System;

namespace SUP.Repository
{
    public partial class Task
    {
        public String PerformerName => Performer is null ? "Отсутствует" : $"{Performer.LastName} {Performer.FirstName}"; // вывод сотрудника, который закреплен на выполнение задачи
        public String TesterName => Tester is null ? "Отсутствует" : $"{Tester.LastName} {Tester.FirstName}"; // вывод сотрудника, который закреплен на тестирование задачи
    }
}
