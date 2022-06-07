using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUP.Validator.Models;

namespace SUP.Validator
{
    public static class Validator
    {
        public static Result ValidateProject(String projectName, String projectDescription)
        {
            if (String.IsNullOrWhiteSpace(projectName)) return Result.Fail("Не введено название проекта");
            if (String.IsNullOrWhiteSpace(projectDescription)) return Result.Fail("Не введено описание проекта");

            return Result.Success();
        }

        public static Result ValidateEmployee(String fisrtName, String lastName, Object type)
        {
            if (String.IsNullOrWhiteSpace(fisrtName)) return Result.Fail("Не введено имя сотрудника");
            if (String.IsNullOrWhiteSpace(lastName)) return Result.Fail("Не введена фамилия проекта");
            if (type is null) return Result.Fail("Не выбран тип сотрудника");

            return Result.Success();
        }

        public static Result ValidateVacation(Guid employeeId, DateTime? dateStart, DateTime? dateEnd)
        {
            if (employeeId == Guid.Empty) return Result.Fail("Не выбран сотрудник");
            if (dateStart is null) return Result.Fail("Не выбрана дата начала отпуска");
            if (dateEnd is null) return Result.Fail("Не выбрана дата окончания отпуска");

            return Result.Success();
        }

    }
}
