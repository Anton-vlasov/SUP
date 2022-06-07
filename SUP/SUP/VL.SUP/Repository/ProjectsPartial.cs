using System;
using System.Linq;

namespace SUP.Repository
{
    public partial class Project
    {
        public Int32 BacklogTaskCount
        {
            get
            {
                return Tasks.Where(t => t.State == App.BacklogTaskState).Count();  // вывод количества задач, которые в состоянии "в ожидании"
            }
        }

        public Int32 InWorkTaskCount
        {
            get
            {
                return Tasks.Where(t => t.State == App.InWorkTaskState).Count(); // вывод количества задач, которые в состоянии "в работе"
            }
        }
        public Int32 CompletedTaskCount
        {
            get
            {
                return Tasks.Where(t => t.State == App.CompletedTaskState).Count(); // вывод количества задач, которые в состоянии "выполнено"
            }
        }

        public Int32 EmployeeCount
        {
            get
            {
                return ProjectWorks.Where(pw => pw.DateEnd == null).Count(); // вывод количества сотрудников, которые работают за данным проектом
            }
        }

        public Employee[] Employees
        {
            get
            {
                return ProjectWorks.Where(pw => pw.DateEnd == null).Select(pw => pw.Employee).ToArray(); 
            }
        }
    }
}
