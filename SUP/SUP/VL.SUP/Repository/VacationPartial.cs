using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUP.Repository
{
    public partial class Vacation
    {
        public String EmployeeName => $"{Employee.LastName} {Employee.FirstName}"; // вывод фамилии и имя сотрудника, который находится в отпуске
        public String Period => $"{DateStartOnlyDate} - {DateEndOnlyDate}"; // период отпуска сотрудника
        public String DateStartOnlyDate => $"{DateStart.Day}.{DateStart.Month}.{DateStart.Year}"; // дата начала отпуска сотрудника
        public String DateEndOnlyDate => $"{DateEnd.Day}.{DateEnd.Month}.{DateEnd.Year}"; // дата конца отпуска сотрудника
    }
}
