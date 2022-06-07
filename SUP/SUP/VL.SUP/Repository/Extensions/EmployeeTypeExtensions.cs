using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUP.Views;
using static SUP.Views.EmployeesPage;

namespace SUP.Repository.Extensions
{
    public static class EmployeeTypeExtensions
    {
        public static FilterEmployeeType ToFilterEmployeeType(this EmployeeType type)
        {
            if (type.Title.ToLower().Contains("junior")) return FilterEmployeeType.Juniors;
            if (type.Title.ToLower().Contains("middle")) return FilterEmployeeType.Middles;
            return FilterEmployeeType.Seniors;
        }
    }
}
